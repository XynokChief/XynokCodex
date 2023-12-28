using System;
using UnityEngine.Events;
using XynokConvention.APIs;

namespace XynokConvention.Procedural
{
    [Serializable]
    public class UnityEventWrapper : IAction
    {
        public UnityEvent unityEvent;

        public void Invoke()
        {
            unityEvent?.Invoke();
        }

        public void AddListener(Action action)
        {
            RemoveListener(action);
            unityEvent.AddListener(action.Invoke);
        }

        public void RemoveListener(Action action)
        {
            unityEvent.RemoveListener(action.Invoke);
        }
    }
}