using System;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using XynokConvention.APIs;

namespace XynokGUI.Input
{
    public class InputMap : IInjectable<InputActionMap>
    {
        private string _name;
        public string Name => _name;
        private InputActionWrapper[] _actions;
        private InputActionMap _sourceMap;
        private Action _onDispose;

        public void SetDependency(InputActionMap dependency)
        {
            if (_sourceMap != null) Dispose();
            _sourceMap = dependency;
            if (_sourceMap == null)
            {
                Debug.LogError("_sourceMap is null");
                return;
            }

            Init();
        }

        public InputActionWrapper GetInputAction(string actionType)
        {
            var result = _actions.FirstOrDefault(e => e.name == actionType);
            if (result == null)
            {
#if XYNOK_DEBUGGER_ERROR_LOG

                Debug.LogError($"Action {actionType} not found in map {_name}");
#endif
            }

            return result;
        }

        void Init()
        {
            _name = _sourceMap.name;
            _actions = new InputActionWrapper[_sourceMap.actions.Count];
            for (int i = 0; i < _sourceMap.actions.Count; i++)
            {
                int index = i;
                _actions[index] ??= new();
                _actions[index].SetDependency(_sourceMap.actions[index]);
                _onDispose += _actions[index].Dispose;
            }
        }

        public void Dispose()
        {
            _name = default;
            _onDispose?.Invoke();
        }
    }
}