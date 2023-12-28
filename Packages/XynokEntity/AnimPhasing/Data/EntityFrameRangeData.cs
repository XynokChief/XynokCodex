using System;
using Sirenix.OdinInspector;
using UnityEngine;
using XynokConvention;
using XynokConvention.APIs;
using XynokConvention.Procedural;
using XynokEntity.APIs;

namespace XynokEntity.AnimPhasing.Data
{
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

        [MinMaxSlider(1, "@clipFrameCount", showFields: true)]
        public Vector2Int range = new Vector2Int(1, 1);

        [VerticalGroup(ConventionKey.Events)] [SerializeReference] [HideReferenceObjectPicker]
        IAction onEnter = new UnityEventWrapper();

        [VerticalGroup(ConventionKey.Events)] [SerializeReference] [HideReferenceObjectPicker]
        IAction onExit = new UnityEventWrapper();

        [HideInInspector] public int clipFrameCount = 3;

        private bool _isPerforming;

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
    }
}