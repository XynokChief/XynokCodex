using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using XynokConvention;
using XynokConvention.APIs;
using XynokConvention.Procedural;
using XynokEntity.APIs;
using XynokEntity.Enums;

namespace XynokEntity.AnimPhasing.Data
{
    /// <summary>
    /// lưu trữ thông tin về frame range của anim
    /// </summary>
    /// <typeparam name="T">anim owner</typeparam>
    [Serializable]
    public class EntityFrameRangeData<T> : IAnimOverrideAble, IInjectable<T> where T : IEntity
    {
        [VerticalGroup(ConventionKey.State)] [LabelWidth(80)]
        public FrameRangeType rangeType;

        [Tooltip("if true, that mean anim is playing in this range")]
        [VerticalGroup(ConventionKey.State)]
        [ShowInInspector]
        [ReadOnly]
        [LabelWidth(80)]
        public bool IsPerforming => _isPerforming;


        // ------------------ Overridable ------------------

        [VerticalGroup(ConventionKey.State)]
        [ShowIf(nameof(rangeType), FrameRangeType.Overridable)]
        [LabelWidth(160)]
        [ReadOnly]
        [Tooltip("now only support 1 overrider at a time, if want more, must has a specification design")]
        public int maxInterruptConcurrency = 1;

        [VerticalGroup(ConventionKey.State)] [ShowIf(nameof(rangeType), FrameRangeType.Overridable)] [HideLabel]
        public AnimOverriderData[] overriders;
        // ------------------ Overridable ------------------

        [MinMaxSlider(1, "@clipFrameCount", showFields: true)]
        public Vector2Int range = new Vector2Int(1, 1);

        [VerticalGroup(ConventionKey.Events)] [SerializeReference] [HideReferenceObjectPicker]
        IAction onEnter = new UnityEventWrapper();

        [VerticalGroup(ConventionKey.Events)] [SerializeReference] [HideReferenceObjectPicker]
        IAction onExit = new UnityEventWrapper();

        [HideInInspector] public int clipFrameCount = 3;


        private bool _isPerforming;
        private Queue<IActionAnimOverrider> _overriderQueue = new();

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
            Exit(true);
        }

        void Enter()
        {
            _isPerforming = true;
            onEnter?.Invoke();
        }

        void Exit(bool isForce = false)
        {
            // reset
            _isPerforming = false;

            // invoke exit
            onExit?.Invoke();

            // nếu là force thì không cần xét overrider
            if (isForce)
            {
                _overriderQueue.Clear();
                return;
            }

            // invoke overriders
            if (_overriderQueue.Count < 1) return;
            for (int i = 0; i < _overriderQueue.Count; i++)
            {
                _overriderQueue.Dequeue()?.AnimOverrideAct?.Invoke();
            }
        }

        #endregion

        public void RegisterOverrider(IActionAnimOverrider overrider)
        {
            var overriderData = overriders.FirstOrDefault(e => e.name == overrider.AnimOverrideActName);

            // validate before register
            if (overriderData == null) return;


            // handle override
            if (overriderData.handler == AnimOverrideHandlerType.Allow)
            {
                // allow overrider executes
                _overriderQueue.Clear();
                overrider.AnimOverrideAct?.Invoke();
                return;
            }

            if (overriderData.handler != AnimOverrideHandlerType.Cache) return;
            if (_overriderQueue.Count >= maxInterruptConcurrency) return;
            if (_overriderQueue.Contains(overrider)) return;

            _overriderQueue.Enqueue(overrider);
        }
    }
}