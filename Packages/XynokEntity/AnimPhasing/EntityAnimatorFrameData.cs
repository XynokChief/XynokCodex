using Sirenix.OdinInspector;
using UnityEngine;
using XynokConvention;
using XynokEntity.AnimPhasing.Data;

namespace XynokEntity.AnimPhasing
{
    public class EntityAnimatorFrameData : MonoBehaviour
    {
        [FoldoutGroup(ConventionKey.Settings)] public Animator animator;

        [FoldoutGroup(ConventionKey.Settings)] [TableList]
        public AnimClipData[] clipsData;

        [FoldoutGroup(ConventionKey.Settings)]
        [Button, GUIColor(0.4f, 0.8f, 1)]
        void InitClipData()
        {
            var clips = animator.runtimeAnimatorController.animationClips;
            
            clipsData = new AnimClipData[clips.Length];

            for (int i = 0; i < clips.Length; i++)
            {
                var clip = clips[i];
                var clipData = new AnimClipData
                {
                    clip = clip,
                    frameCount = (int)(clip.frameRate * clip.length)
                };
                clipData.InitFrameRanges();
                clipsData[i] = clipData;
            }
        }

        [Button]
        void GetCurrentAnim()
        {
            string result = "";
            var currentAnimatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
            
            var currentAnimatorClipInfo = animator.GetCurrentAnimatorClipInfo(0);
            
            var currentClip = currentAnimatorClipInfo[0].clip;
            var currentFrame = (currentAnimatorStateInfo.normalizedTime % 1) * currentClip.frameRate;
            result += $"[{currentClip.name}]: {currentFrame} ";
            Debug.Log($"{result}");
        }
    }
}