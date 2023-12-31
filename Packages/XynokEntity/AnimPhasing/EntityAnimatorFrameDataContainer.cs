using System;
using Sirenix.OdinInspector;
using UnityEngine;
using XynokConvention;
using XynokConvention.APIs;
using XynokConvention.Data.Binding;
using XynokEntity.AnimPhasing.Data;
using XynokEntity.APIs;

namespace XynokEntity.AnimPhasing
{
    /// <summary>
    /// animator of unity is so confusing, so i create this class to make it easier to understand.
    /// <inheritdoc cref="https://forum.unity.com/threads/problem-with-statemachinebehaviour-onstateexit.359418/"/>
    /// TODO: bổ sung thêm SG cho case generic events
    /// </summary>
    public class EntityAnimatorFrameDataContainer<T> : MonoBehaviour, IAnimOverrideAble, IInjectable<T>
        where T : IEntity
    {
        [FoldoutGroup(ConventionKey.Settings)] public Animator animator;
        [FoldoutGroup(ConventionKey.Settings)] public bool useBindAbleCurrentState;

        [FoldoutGroup(ConventionKey.Settings)] [ShowIf(nameof(useBindAbleCurrentState))]
        public bool ignoreLoopState;


        [FoldoutGroup(ConventionKey.Settings)] [TableList]
        public EntityAnimClipData<T>[] clipsData;

        [Tooltip("state hiện tại của animator (ignored transition)")] [ShowIf(nameof(useBindAbleCurrentState))]
        public StringData currentAnimStateData;

        [Tooltip("state hiện tại của animator (ignored transition)")]
        [HideIf(nameof(useBindAbleCurrentState))]
        [ShowInInspector]
        public string CurrentAnimState => _currentAnimState;


        private string _currentAnimState;
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
            if (useBindAbleCurrentState) currentAnimStateData.SetDuplicateCheck(!ignoreLoopState);
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

        public void RegisterOverrider(IActionAnimOverrider overrider)
        {
            var currentClip = GetClipData(useBindAbleCurrentState ? currentAnimStateData.Value : _currentAnimState);
            currentClip?.RegisterOverrider(overrider);
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

        #region Anim Events

        /// <summary>
        /// <inheritdoc cref="XynokConvention.ConventionKey.AnimEvent"/>
        /// </summary>
        void AnimEvent(string message)
        {
            // translate message to data
            var data = message.Split(ConventionKey.Separator);

            var eventType = Enum.Parse<FrameRangeEventType>(data[0]);
            var clipName = data[1];
            var rangeType = Enum.Parse<FrameRangeType>(data[2]);
            var range = new Vector2Int(int.Parse(data[3]), int.Parse(data[4]));

            // fetch clip data
            var clipData = GetClipData(clipName);
            if (clipData == null) return;

            // fetch frame range data
            var frameRangeData = clipData.GetFrameRangeData(rangeType, range);
            if (frameRangeData == null) return;

            // invoke frame range data
            frameRangeData.Invoke(eventType);
        }

        /// <summary>
        /// <inheritdoc cref="XynokConvention.ConventionKey.AnimStartEvent"/>
        /// </summary>
        void StartEvent(string clipName)
        {
            if (useBindAbleCurrentState) currentAnimStateData.Value = clipName;
            else _currentAnimState = clipName;
        }

        #endregion

        #endregion
    }
}