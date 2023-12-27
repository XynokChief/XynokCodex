using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace XynokEntity.AnimPhasing.Data
{
    [Serializable]
    public class AnimClipData
    {
        [VerticalGroup("clip data")] [HideLabel]
        public AnimationClip clip;

        [VerticalGroup("clip data")] [ReadOnly] [HideLabel] [SuffixLabel("frames", overlay: true)]
        public int frameCount;

        [TableList] public FrameRangeData[] frameRanges;

        [VerticalGroup("clip data")]
        [Button(ButtonSizes.Medium), GUIColor(0.4f, 0.8f, 1)]
        public void InitFrameRanges()
        {
            frameRanges = new FrameRangeData[Enum.GetNames(typeof(FrameRangeType)).Length];
            for (int i = 0; i < frameRanges.Length; i++)
            {
                var frameRangeData = new FrameRangeData
                {
                    rangeType = (FrameRangeType)i,
                    clipFrameCount = frameCount
                };
                frameRanges[i] = frameRangeData;
            }
        }
    }

    [Serializable]
    public class FrameRangeData
    {
        public FrameRangeType rangeType;

        [MinMaxSlider(1, "@clipFrameCount", showFields: true)]
        public Vector2Int range = new Vector2Int(1, 1);

        [HideInInspector] public int clipFrameCount = 3;
    }
}