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
        [VerticalGroup(ConventionKey.State)] [LabelWidth(80)] [TableColumnWidth(300, Resizable = false)]
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
        [Tooltip("Hiện tại chỉ hỗ trợ 1 overrider vào một thời điểm, nếu muốn nhiều hơn, cần có một thiết kế cụ thể")]
        public int maxInterruptConcurrency = 1;

        [VerticalGroup(ConventionKey.State)]
        [ShowIf(nameof(rangeType), FrameRangeType.Overridable)]
        [HideLabel]
        [Tooltip("các overrider có thể override frame range này")]
        public AnimOverriderData[] overriders;
        // ------------------ Overridable - end ------------------

        [MinMaxSlider(1, "@clipFrameCount", showFields: true)] [TableColumnWidth(320, Resizable = false)]
        public Vector2Int range = new Vector2Int(1, 3);

        [VerticalGroup(ConventionKey.Events)] [SerializeReference] [HideReferenceObjectPicker]
        public IAction onEnter = new UnityEventWrapper();

        [VerticalGroup(ConventionKey.Events)] [SerializeReference] [HideReferenceObjectPicker]
        public IAction onExit = new UnityEventWrapper();

        [VerticalGroup(ConventionKey.Events)] [SerializeReference] [HideReferenceObjectPicker]
        public IAction onForceExit = new UnityEventWrapper();

        [HideInInspector] public int clipFrameCount = 3;


        public int OverriderLeft => _overriderQueue.Count;
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

        public void Invoke(FrameRangeEventType eventType)
        {
            switch (eventType)
            {
                case FrameRangeEventType.Start:
                    Enter();
                    return;
                case FrameRangeEventType.End:
                    Exit();
                    return;
            }

            Debug.LogError($"{GetType().Name}: Invalid frame range event - {eventType}");
        }

        public void ForceExit()
        {
            _overriderQueue?.Clear();
            Exit();
            onForceExit?.Invoke();
        }

        void Enter()
        {
            _isPerforming = true;
            onEnter?.Invoke();
        }

        void Exit()
        {
            // reset
            _isPerforming = false;

            // invoke exit
            onExit?.Invoke();

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
            var overriderData = overriders.FirstOrDefault(e => e.actionName == overrider.AnimOverrideActName);

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