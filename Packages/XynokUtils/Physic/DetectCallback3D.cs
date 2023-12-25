using Sirenix.OdinInspector;
using UnityEngine;
using XynokConvention;
using XynokUtils.Physics.Data;

namespace XynokUtils.Physic
{
    [RequireComponent(typeof(Collider))]
    public class DetectCallback3D : MonoBehaviour
    {
        [FoldoutGroup(ConventionKey.Settings)] [SerializeField]
        private LayerMask interactableLayer;

        [FoldoutGroup(ConventionKey.Settings)] [SerializeField]
        private OrderInvokeCallback executeOrder;

        [FoldoutGroup(ConventionKey.Settings)] public TriggerCallback3D onTriggerEnter;
        [FoldoutGroup(ConventionKey.Settings)] public TriggerCallback3D onTriggerExit;
        [FoldoutGroup(ConventionKey.Settings)] public CollisionCallback3D onCollisionEnter;
        [FoldoutGroup(ConventionKey.Settings)] public CollisionCallback3D onCollisionExit;

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