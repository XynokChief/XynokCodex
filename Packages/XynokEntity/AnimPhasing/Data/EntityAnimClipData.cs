using System;
using Sirenix.OdinInspector;
using UnityEngine;
using XynokConvention;
using XynokConvention.APIs;
using XynokEntity.APIs;


namespace XynokEntity.AnimPhasing.Data
{
    [Serializable]
    public class EntityAnimClipData<T> : IInjectable<T> where T : IEntity
    {
        [VerticalGroup(ConventionKey.AnimClipData)] [HideLabel]
        public AnimationClip clip;

        [VerticalGroup(ConventionKey.AnimClipData)] [ReadOnly] [HideLabel] [SuffixLabel("frames", overlay: true)]
        public int frameCount;

        [TableList] public EntityFrameRangeData<T>[] frameRanges;

        private int FrameRangeAmount => Enum.GetNames(typeof(FrameRangeType)).Length;

        private T _owner;
        private Action _onDispose;

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
            var animEvents = new AnimationEvent[frameRanges.Length * 2];
            int count = 0;
            for (int i = 0; i < frameRanges.Length; i++)
            {
                int indexIn = i + count;
                int indexOut = indexIn + 1;
                var frameRangeData = frameRanges[i];

                var startMessageParameters = new string[]
                {
                    RangeMilestone.Start.ToString(),
                    clip.name,
                    frameRangeData.rangeType.ToString()
                };
                var startEvent = new AnimationEvent
                {
                    functionName = ConventionKey.AnimEvent,
                    time = frameRangeData.range.x / (float)frameRangeData.clipFrameCount,
                    stringParameter = ConventionKey.GetStrInterpolatedBySeparator(startMessageParameters)
                };

                var endMessageParameters = new string[]
                {
                    RangeMilestone.End.ToString(),
                    clip.name,
                    frameRangeData.rangeType.ToString()
                };

                var endEvent = new AnimationEvent
                {
                    functionName = ConventionKey.AnimEvent,
                    time = frameRangeData.range.y / (float)frameRangeData.clipFrameCount,
                    stringParameter = ConventionKey.GetStrInterpolatedBySeparator(endMessageParameters)
                };
                animEvents[indexIn] = startEvent;
                animEvents[indexOut] = endEvent;
                count++;
            }

            UnityEditor.AnimationUtility.SetAnimationEvents(clip, animEvents);
#endif
        }

        [VerticalGroup(ConventionKey.AnimClipData)]
        [Button(ButtonSizes.Medium), GUIColor(Colors.Orange)]
        void ClearAllAnimEvents()
        {
#if UNITY_EDITOR
            UnityEditor.AnimationUtility.SetAnimationEvents(clip, Array.Empty<AnimationEvent>());
#endif
        }

        #endregion

        public EntityFrameRangeData<T> GetFrameRangeData(FrameRangeType rangeType)
        {
            foreach (var frameRangeData in frameRanges)
            {
                if (frameRangeData.rangeType == rangeType) return frameRangeData;
            }

            Debug.LogError($"[{GetType().Name}]: {rangeType} not found !");
            return null;
        }
    }
}