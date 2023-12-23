using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;
using XynokConvention.Data.Binding;
using XynokConvention.Enums;
using XynokConvention.Patterns;

namespace XynokConvention.Procedural
{
 
    [Serializable]
    public class TimeScaleData
    {
        [Range(.1f, 10f)] public float duration = 0.5f;
        [Range(0f, .999f)] public float timeScaleOnStart = 0.1f;
    }

    public class TimeCycle : ASingleton<TimeCycle>
    {
        [SerializeField] private FloatData timeScaler;

        private Action _onUpdate;
        private Action _onLateUpdate;
        private Action _onFixedUpdate;
        private Action _onRealtimeUpdate;
        bool _waiting;
        private Coroutine _coroutineSlowMotion;

        private void Start()
        {
            timeScaler.SetBaseValue(Time.timeScale);
            timeScaler.OnChanged += SetTimeScale;
        }

        [Button]
        public void SetTimeScale(float value)
        {
            Time.timeScale = value;
        }


        public void AddInvoker(Action action, UpdateMode updateMode = UpdateMode.Update)
        {
            if (updateMode == UpdateMode.Update )
            {
                _onUpdate -= action;
                _onUpdate += action;
                return;
            }

            if (updateMode == UpdateMode.FixedUpdate)
            {
                _onFixedUpdate -= action;
                _onFixedUpdate += action;
                return;
            }

            if (updateMode == UpdateMode.LateUpdate)
            {
                _onLateUpdate -= action;
                _onLateUpdate += action;
            }
        }

        public void RemoveInvoker(Action action, UpdateMode updateMode = UpdateMode.Update)
        {
            if (updateMode == UpdateMode.Update)
            {
                _onUpdate -= action;
                return;
            }

            if (updateMode == UpdateMode.FixedUpdate)
            {
                _onFixedUpdate -= action;
                return;
            }

            if (updateMode == UpdateMode.LateUpdate)
            {
                _onLateUpdate -= action;
            }
        }

        private void LateUpdate()
        {
            _onLateUpdate?.Invoke();
        }

        private void Update()
        {
            _onRealtimeUpdate?.Invoke();
            _onUpdate?.Invoke();
        }

        private void FixedUpdate()
        {
            _onFixedUpdate?.Invoke();
        }

        public void RemoveAllInvoker(UpdateMode updateMode)
        {
            if (updateMode == UpdateMode.Update) _onUpdate = default;
            if (updateMode == UpdateMode.FixedUpdate) _onFixedUpdate = default;
            if (updateMode == UpdateMode.LateUpdate) _onLateUpdate = default;
        }


        public void ForceSetTimeScale(TimeScaleData data)
        {
            ResetTimeScale();
            StartSlowMotion(data.duration, data.timeScaleOnStart);
        }

        public void SetTimeScale(TimeScaleData data)
        {
            if (_waiting) return;
            ResetTimeScale();
            StartSlowMotion(data.duration, data.timeScaleOnStart);
        }

        void StartSlowMotion(float duration, float timeScale)
        {
            Time.timeScale = timeScale;
            _coroutineSlowMotion = StartCoroutine(Wait(duration));
        }

        IEnumerator Wait(float duration)
        {
            _waiting = true;
            yield return new WaitForSecondsRealtime(duration);
            Time.timeScale = 1.0f;
            _waiting = false;
        }

        public void ResetTimeScale()
        {
            if (_coroutineSlowMotion != null) StopCoroutine(_coroutineSlowMotion);
            _coroutineSlowMotion = null;
            Time.timeScale = 1.0f;
            _waiting = false;
        }

        private void OnDestroy()
        {
            timeScaler.OnChanged -= SetTimeScale;
            ResetTimeScale();
        }
    }
}