using System;
using Sirenix.OdinInspector;
using UnityEngine;
using XynokConvention;
using XynokConvention.APIs;
using XynokConvention.Procedural;
using XynokEntity.APIs;

namespace XynokEntity.AnimPhasing.Data
{
    /// <summary>
    /// lưu trữ thông tin về frame range của anim
    /// </summary>
    /// <typeparam name="T">anim owner</typeparam>
    [Serializable]
    public class EntityFrameRangeData<T> : IInjectable<T> where T : IEntity
    {
        [VerticalGroup(ConventionKey.State)] [LabelWidth(80)]
        public FrameRangeType rangeType;

        [Tooltip("if true, that mean anim is playing in this range")]
        [VerticalGroup(ConventionKey.State)]
        [ShowInInspector]
        [ReadOnly]
        [LabelWidth(80)]
        public bool IsPerforming => _isPerforming;

        [VerticalGroup(ConventionKey.State)]
        [ShowIf(nameof(rangeType), FrameRangeType.Overridable)]
        [Range(1, 3)]
        [LabelWidth(160)]
        public int maxInterruptConcurrency = 1;

        [VerticalGroup(ConventionKey.State)] [ShowIf(nameof(rangeType), FrameRangeType.Overridable)] [HideLabel]
        public AnimOverriderData[] overriders;

        [MinMaxSlider(1, "@clipFrameCount", showFields: true)]
        public Vector2Int range = new Vector2Int(1, 1);

        [VerticalGroup(ConventionKey.Events)] [SerializeReference] [HideReferenceObjectPicker]
        IAction onEnter = new UnityEventWrapper();

        [VerticalGroup(ConventionKey.Events)] [SerializeReference] [HideReferenceObjectPicker]
        IAction onExit = new UnityEventWrapper();

        [HideInInspector] public int clipFrameCount = 3;

        private bool _isPerforming;

        #region Dependency

        public void SetDependency(T dependency)
        {
            Dispose();
            if (onEnter is IInjectable<T> enter) enter.SetDependency(dependency);
            if (onExit is IInjectable<T> exit) exit.SetDependency(dependency);
        }

        public void Dispose()
        {
            if (onEnter is IInjectable<T> enter) enter.Dispose();
            if (onExit is IInjectable<T> exit) exit.Dispose();
        }

        #endregion

        #region Runtime

        public void Invoke(RangeMilestone milestone)
        {
            switch (milestone)
            {
                case RangeMilestone.Start:
                    Enter();
                    return;
                case RangeMilestone.End:
                    Exit();
                    return;
            }

            Debug.LogError($"{GetType().Name}: Invalid milestone {milestone}");
        }

        public void ForceExit()
        {
            Exit();
        }

        void Enter()
        {
            _isPerforming = true;
            onEnter?.Invoke();
        }

        void Exit()
        {
            _isPerforming = false;
            onExit?.Invoke();
        }

        #endregion
    }
}