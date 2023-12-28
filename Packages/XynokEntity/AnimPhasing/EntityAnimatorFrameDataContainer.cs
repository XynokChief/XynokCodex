using System;
using Sirenix.OdinInspector;
using UnityEngine;
using XynokConvention;
using XynokConvention.APIs;
using XynokEntity.AnimPhasing.Data;
using XynokEntity.APIs;

namespace XynokEntity.AnimPhasing
{
    /// <summary>
    /// animator of unity is so confusing, so i create this class to make it easier to understand. <inheritdoc cref="https://forum.unity.com/threads/problem-with-statemachinebehaviour-onstateexit.359418/"/>
    /// </summary>
    public class EntityAnimatorFrameDataContainer<T> : MonoBehaviour, IInjectable<T>
        where T : IEntity
    {
        [FoldoutGroup(ConventionKey.Settings)] public Animator animator;

        [FoldoutGroup(ConventionKey.Settings)] [TableList]
        public EntityAnimClipData<T>[] clipsData;

        private T _owner;
        private Action _onDispose;


        #region Denpendency Injection

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

        #endregion

        #region Editors

        [FoldoutGroup(ConventionKey.Settings)]
        [Button(ButtonSizes.Medium), GUIColor(Colors.Blue)]
        void InitClipsData()
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


        

        #endregion

        #region Runtime

        /// <summary>
        /// call this to catch state exit events if an anim did not run to the end
        /// </summary>
        /// <param name="stateName">name of state on animator, at this context of XynokCodex, state's name is the same as anim clip's name</param>
        public void ResolveStateOnExit(string stateName)
        {
            var clip = GetClipData(stateName);
            if (clip == null) return;

            foreach (var frameRange in clip.frameRanges)
            {
                if (!frameRange.IsPerforming) continue;
                frameRange.ForceExit();
            }
        }

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

        #endregion
    }
}