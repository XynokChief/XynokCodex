using System;
using UnityEngine;
using UnityEngine.Events;
using XynokUtils.Physic;

namespace XynokUtils.Physics.Data
{
    [Serializable]
    public class TriggerCallback3D
    {
        public event Action<Collider> EventCallback;
        public UnityEvent unityEvent;

        public void Invoke(Collider other, OrderInvokeCallback order)
        {
            if (order == OrderInvokeCallback.EventActionFirst)
            {
                EventCallback?.Invoke(other);
                unityEvent?.Invoke();
                return;
            }

            if (order == OrderInvokeCallback.UnityEventFirst)
            {
                unityEvent?.Invoke();
                EventCallback?.Invoke(other);
                return;
            }
        }
    }
    [Serializable]
    public class CollisionCallback3D
    {
        public event Action<Collision> EventCallback;
        public UnityEvent unityEvent;

        public void Invoke(Collision other, OrderInvokeCallback order)
        {
            if (order == OrderInvokeCallback.EventActionFirst)
            {
                EventCallback?.Invoke(other);
                unityEvent?.Invoke();
                return;
            }

            if (order == OrderInvokeCallback.UnityEventFirst)
            {
                unityEvent?.Invoke();
                EventCallback?.Invoke(other);
                return;
            }
        }
    }
}