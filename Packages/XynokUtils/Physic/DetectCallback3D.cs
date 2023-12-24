using System;
using UnityEngine;
using XynokUtils.Physics.Data;

namespace XynokUtils.Physic
{
    [RequireComponent(typeof(Collider))]
    public class DetectCallback3D: MonoBehaviour
    {
        [Header("COLLISION SETTING")] [SerializeField]
        private LayerMask interactableLayer;

        [SerializeField] private OrderInvokeCallback executeOrder;
        public TriggerCallback3D onTriggerEnter;
        public TriggerCallback3D onTriggerExit;
        public CollisionCallback3D onCollisionEnter;
        public CollisionCallback3D onCollisionExit;

        private void OnTriggerEnter(Collider other)
        {
            if (!XynokUtility.PhysicUtils.IsLayer(other, interactableLayer)) return;

            onTriggerEnter.Invoke(other, executeOrder);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!XynokUtility.PhysicUtils.IsLayer(other, interactableLayer)) return;

            onTriggerExit.Invoke(other, executeOrder);
        }

        private void OnCollisionEnter(Collision other)
        {
            if (!XynokUtility.PhysicUtils.IsLayer(other, interactableLayer)) return;

            onCollisionEnter.Invoke(other, executeOrder);
        }

        private void OnCollisionExit(Collision other)
        {
            if (!XynokUtility.PhysicUtils.IsLayer(other, interactableLayer)) return;
            onCollisionExit.Invoke(other, executeOrder);
        }
    }
}