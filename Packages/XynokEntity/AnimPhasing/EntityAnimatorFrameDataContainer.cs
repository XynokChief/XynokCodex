using System;
using Sirenix.OdinInspector;
using UnityEngine;
using XynokConvention;
using XynokConvention.APIs;
using XynokEntity.AnimPhasing.Data;
using XynokEntity.APIs;

namespace XynokEntity.AnimPhasing
{
    public class EntityAnimatorFrameDataContainer<T> : MonoBehaviour, IInjectable<T>
        where T : IEntity
    {
        [FoldoutGroup(ConventionKey.Settings)] public Animator animator;

        [FoldoutGroup(ConventionKey.Settings)] [TableList]
        public EntityAnimClipData<T>[] clipsData;

        private T _owner;
        private Action _onDispose;

        public virtual void SetDependency(T dependency)
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

        public virtual void Dispose()
        {
            _onDispose?.Invoke();
            _onDispose = default;
        }


        void Init()
        {
            foreach (var clip in clipsData)
            {
                clip.SetDependency(_owner);
                _onDispose += clip.Dispose;
            }
        }

        private void OnDestroy()
        {
            Dispose();
        }


        [FoldoutGroup(ConventionKey.Settings)]
        [Button, GUIColor(Colors.Blue)]
        void InitClipData()
        {
            var clips = animator.runtimeAnimatorController.animationClips;

            clipsData = new EntityAnimClipData<T>[clips.Length];

            for (int i = 0; i < clips.Length; i++)
            {
                var clip = clips[i];
                var clipData = new EntityAnimClipData<T>
                {
                    clip = clip,
                };
                clipData.InitFrameRanges();
                clipsData[i] = clipData;
            }
        }

        // [Button]
        // void GetCurrentAnim()
        // {
        //     string result = "";
        //     var currentAnimatorStateInfo = animator.GetCurrentAnimatorStateInfo(0);
        //
        //     var currentAnimatorClipInfo = animator.GetCurrentAnimatorClipInfo(0);
        //
        //     var currentClip = currentAnimatorClipInfo[0].clip;
        //     var currentFrame = (currentAnimatorStateInfo.normalizedTime % 1) * currentClip.frameRate;
        //     result += $"[{currentClip.name}]: {currentFrame} ";
        //     Debug.Log($"{result}");
        // }


        void AnimEvent(string message)
        {
            // translate message to data
            var data = message.Split(ConventionKey.Separator);

            var rangeMilestone = Enum.Parse<RangeMilestone>(data[0]);
            var clipName = data[1];
            var rangeType = Enum.Parse<FrameRangeType>(data[2]);

            // fetch clip data
            var clipData = GetClipData(clipName);
            if (clipData == null) return;

            // fetch frame range data
            var frameRangeData = clipData.GetFrameRangeData(rangeType);
            if (frameRangeData == null) return;

            // invoke frame range data
            frameRangeData.Invoke(rangeMilestone);
        }

        EntityAnimClipData<T> GetClipData(string clipName)
        {
            foreach (var clipData in clipsData)
            {
                if (clipData.clip.name == clipName) return clipData;
            }

            Debug.LogError($"[{GetType().Name}]: clip {clipName} not found !");
            return null;
        }
    }
}