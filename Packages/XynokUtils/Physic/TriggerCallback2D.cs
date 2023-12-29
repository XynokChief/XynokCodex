using System;
using UnityEngine;
using UnityEngine.Events;
using XynokUtils.Physic;

namespace XynokUtils.Physics.Data
{
    [Serializable]
    public class TriggerCallback2D
    {
        public event Action<Collider2D> EventCallback;
        public UnityEvent unityEvent;

        public void Invoke(Collider2D other, OrderInvokeCallback order)
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
    public class CollisionCallback2D
    {
        public event Action<Collision2D> EventCallback;
        public UnityEvent unityEvent;
        
        public void Invoke(Collision2D other, OrderInvokeCallback order)
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