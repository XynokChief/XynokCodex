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
        [FoldoutGroup("$ClipName")]
        [Title("$ClipName", "@frameCount", TitleAlignments.Centered)]
        [TableColumnWidth(250, Resizable = false)]
        [HideLabel]
        public AnimationClip clip;

        public string ClipName => !clip ? "???" : clip.name;
        private bool _isPerforming;

        [FoldoutGroup("$ClipName")] [ReadOnly] [HideLabel] [SuffixLabel(ConventionKey.Frames, overlay: true)]
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

        [FoldoutGroup("$ClipName")]
        [Button(ButtonSizes.Medium), GUIColor(Colors.Orange)]
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

        [FoldoutGroup("$ClipName")]
        [Button(ButtonSizes.Medium), GUIColor(Colors.Green)]
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
                    FrameRangeEventType.Start.ToString(),
                    clip.name,
                    frameRangeData.rangeType.ToString(),
                    startRange,
                    endRange
                };
                var startEvent = new AnimationEvent
                {
                    functionName = ConventionKey.AnimEvent,
                    time = (float)frameRangeData.range.x / frameRangeData.clipFrameCount * clip.length,
                    stringParameter = ConventionKey.GetStrInterpolatedBySeparator(startMessageParameters)
                };


                // end event
                var endMessageParameters = new string[]
                {
                    FrameRangeEventType.End.ToString(),
                    clip.name,
                    frameRangeData.rangeType.ToString(),
                    startRange,
                    endRange
                };

                var endEvent = new AnimationEvent
                {
                    functionName = ConventionKey.AnimEvent,
                    time = (float)frameRangeData.range.y / frameRangeData.clipFrameCount * clip.length,
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

        [FoldoutGroup("$ClipName")]
        [Button(ButtonSizes.Medium), GUIColor(Colors.Blue)]
        void ResetFrameAmount()
        {
            frameCount = (int)(clip.frameRate * clip.length);
            foreach (var frameRangeData in frameRanges)
            {
                frameRangeData.clipFrameCount = frameCount;
            }
        }

        [FoldoutGroup("$ClipName")]
        [Button(ButtonSizes.Medium), GUIColor(Colors.Red)]
        void ClearAllAnimEvents()
        {
#if UNITY_EDITOR
            UnityEditor.AnimationUtility.SetAnimationEvents(clip, Array.Empty<AnimationEvent>());
#endif
        }

        // 
        // [Button(ButtonSizes.Medium), GUIColor(Colors.Orange)]
        // void AddFrameRange(FrameRangeType rangeType)
        // {
        //     var frameRangeData = new EntityFrameRangeData<T>
        //     {
        //         rangeType = rangeType,
        //         clipFrameCount = frameCount
        //     };
        //     Array.Resize(ref frameRanges, frameRanges.Length + 1);
        //     frameRanges[^1] = frameRangeData;
        // }

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