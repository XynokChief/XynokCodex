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
    }
}