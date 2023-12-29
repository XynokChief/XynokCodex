using System;
using UnityEngine;
using UnityEngine.InputSystem;
using XynokConvention.APIs;

namespace XynokGUI.Input
{
    public class InputActionWrapper : IInjectable<InputAction>
    {
        public string name;
        public event Action OnStarted;
        public event Action OnPerformed;
        public event Action OnCanceled;
        public event Action<InputAction.CallbackContext> OnContextStarted;
        public event Action<InputAction.CallbackContext> OnContextPerformed;
        public event Action<InputAction.CallbackContext> OnContextCanceled;

        private InputAction _source;
        public InputAction Source => _source;
        private Action _overrider;

        public void SetDependency(InputAction dependency)
        {
            if (_source != null) Dispose();
            _source = dependency;
            if (_source == null)
            {
                Debug.LogError($"InputAction {name} has Source null");
                return;
            }

            Init();
        }


        protected virtual void Init()
        {
            name = _source.name;

            _source.started -= Started;
            _source.started += Started;

            _source.performed -= Performed;
            _source.performed += Performed;

            _source.canceled -= Canceled;
            _source.canceled += Canceled;
        }

        /// <summary>
        /// dangerous method, use with caution
        /// </summary>
        public void AddOverride(Action context)
        {
            _overrider = default;
            _overrider += context;
        }

        public void ResetOverride()
        {
            _overrider = default;
        }

        void Started(InputAction.CallbackContext context)
        {
            if (InvokeOverride()) return;
            OnContextStarted?.Invoke(context);
            OnStarted?.Invoke();
        }

        bool InvokeOverride()
        {
            if (_overrider != default)
            {
                _overrider?.Invoke();
                return true;
            }

            return false;
        }

        void Performed(InputAction.CallbackContext context)
        {
            if (InvokeOverride()) return;
            OnContextPerformed?.Invoke(context);
            OnPerformed?.Invoke();
        }

        void Canceled(InputAction.CallbackContext context)
        {
            if (InvokeOverride()) return;
            OnContextCanceled?.Invoke(context);
            OnCanceled?.Invoke();
        }

        protected virtual void OnDispose()
        {
        }

        public void Dispose()
        {
            _source.started -= Started;
            _source.performed -= Performed;
            _source.canceled -= Canceled;

            OnStarted = default;
            OnContextStarted = default;

            OnCanceled = default;
            OnContextCanceled = default;

            OnPerformed = default;
            OnContextPerformed = default;
            name = default;
            _overrider = default;
            
            OnDispose();
        }
    }
}