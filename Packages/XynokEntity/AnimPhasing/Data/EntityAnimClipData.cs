using System;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using XynokConvention;
using XynokConvention.APIs;
using XynokEntity.APIs;


namespace XynokEntity.AnimPhasing.Data
{
    [Serializable]
    public class EntityAnimClipData<T> : IAnimOverrideAble, IInjectable<T> where T : IEntity
    {
        [VerticalGroup(ConventionKey.AnimClipData)] [HideLabel]
        public AnimationClip clip;

        private bool _isPerforming;

        [VerticalGroup(ConventionKey.AnimClipData)] [ReadOnly] [HideLabel] [SuffixLabel("frames", overlay: true)]
        public int frameCount;

        [TableList] public EntityFrameRangeData<T>[] frameRanges;

        private int FrameRangeAmount => Enum.GetNames(typeof(FrameRangeType)).Length;

        private T _owner;
        private Action _onDispose;

        #region Dependency Injection

        public void SetDependency(T dependency)
        {
            Dispose();
            if (dependency == null)
            {
                Debug.LogError($"[{GetType().Name}]: dependency is null !");
                return;
            }

            _owner = dependency;
            Init();
        }

        public void Dispose()
        {
            _onDispose?.Invoke();
            _onDispose = default;
        }

        void Init()
        {
            foreach (var frameRangeData in frameRanges)
            {
                frameRangeData.SetDependency(_owner);
                _onDispose += frameRangeData.Dispose;
            }
        }

        #endregion

        #region Editor settings

        [VerticalGroup(ConventionKey.AnimClipData)]
        [Button(ButtonSizes.Medium), GUIColor(Colors.Blue)]
        public void InitFrameRanges()
        {
            frameCount = (int)(clip.frameRate * clip.length);
            frameRanges = new EntityFrameRangeData<T>[FrameRangeAmount];
            for (int i = 0; i < frameRanges.Length; i++)
            {
                var frameRangeData = new EntityFrameRangeData<T>
                {
                    rangeType = (FrameRangeType)i,
                    clipFrameCount = frameCount
                };
                frameRanges[i] = frameRangeData;
            }
        }

        [VerticalGroup(ConventionKey.AnimClipData)]
        [Button(ButtonSizes.Medium), GUIColor(Colors.Blue)]
        public void InitAnimEvents()
        {
#if UNITY_EDITOR
            /* 1 is for catching:
             - start of anim at frame 0
             */
            int rangeEventAmount = frameRanges.Length * 2;
            var animEvents = new AnimationEvent[rangeEventAmount + 1];

            // start anim at frame 0
            animEvents[0] = new AnimationEvent
            {
                functionName = ConventionKey.AnimStartEvent,
                time = 0,
                stringParameter = clip.name
            };


            // start and end events for each frame range
            int count = 1;
            for (int i = 0; i < frameRanges.Length; i++)
            {
                int indexIn = i + count;
                int indexOut = indexIn + 1;
                var frameRangeData = frameRanges[i];
                string startRange = frameRangeData.range.x.ToString();
                string endRange = frameRangeData.range.y.ToString();

                // start event
                var startMessageParameters = new string[]
                {
                    RangeMilestone.Start.ToString(),
                    clip.name,
                    frameRangeData.rangeType.ToString(),
                    startRange,
                    endRange
                };
                var startEvent = new AnimationEvent
                {
                    functionName = ConventionKey.AnimEvent,
                    time = frameRangeData.range.x / (float)frameRangeData.clipFrameCount,
                    stringParameter = ConventionKey.GetStrInterpolatedBySeparator(startMessageParameters)
                };


                // end event
                var endMessageParameters = new string[]
                {
                    RangeMilestone.End.ToString(),
                    clip.name,
                    frameRangeData.rangeType.ToString(),
                    startRange,
                    endRange
                };

                var endEvent = new AnimationEvent
                {
                    functionName = ConventionKey.AnimEvent,
                    time = frameRangeData.range.y / (float)frameRangeData.clipFrameCount,
                    stringParameter = ConventionKey.GetStrInterpolatedBySeparator(endMessageParameters)
                };

                // assign
                animEvents[indexIn] = startEvent;
                animEvents[indexOut] = endEvent;
                count++;
            }

            UnityEditor.AnimationUtility.SetAnimationEvents(clip, animEvents);
#endif
        }

        [VerticalGroup(ConventionKey.AnimClipData)]
        [Button(ButtonSizes.Medium), GUIColor(Colors.Red)]
        void ClearAllAnimEvents()
        {
#if UNITY_EDITOR
            UnityEditor.AnimationUtility.SetAnimationEvents(clip, Array.Empty<AnimationEvent>());
#endif
        }

        [VerticalGroup(ConventionKey.AnimClipData)]
        [Button(ButtonSizes.Medium), GUIColor(Colors.Orange)]
        void AddFrameRange(FrameRangeType rangeType)
        {
            var frameRangeData = new EntityFrameRangeData<T>
            {
                rangeType = rangeType,
                clipFrameCount = frameCount
            };
            Array.Resize(ref frameRanges, frameRanges.Length + 1);
            frameRanges[^1] = frameRangeData;
        }

        #endregion

        #region Runtime

        public EntityFrameRangeData<T> GetFrameRangeData(FrameRangeType rangeType, Vector2Int range)
        {
            foreach (var frameRangeData in frameRanges)
            {
                var sameType = frameRangeData.rangeType == rangeType;
                var sameRange = frameRangeData.range == range;

                if (sameType && sameRange) return frameRangeData;
            }

            Debug.LogError($"[{GetType().Name}]: {rangeType} - {range} not found !");
            return null;
        }

        #endregion

        public void RegisterOverrider(IActionAnimOverrider overrider)
        {
            // dù có nhiều range overrideable, nhưng chỉ có 1 range overrideable dc thực hiện
            var overrideAbleRange =
                frameRanges.FirstOrDefault(e => e.rangeType == FrameRangeType.Overridable && e.IsPerforming);
            
            overrideAbleRange?.RegisterOverrider(overrider);
        }
    }
}