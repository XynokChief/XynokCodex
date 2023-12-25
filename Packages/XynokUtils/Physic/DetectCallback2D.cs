using Sirenix.OdinInspector;
using UnityEngine;
using XynokConvention;
using XynokUtils.Physics.Data;

namespace XynokUtils.Physic
{
    public enum OrderInvokeCallback
    {
        EventActionFirst = 0,
        UnityEventFirst = 1,
    }


    [RequireComponent(typeof(Collider2D))]
    public class DetectCallback2D : MonoBehaviour
    {
       [FoldoutGroup(ConventionKey.Settings)] [SerializeField] private LayerMask interactableLayer;
       [FoldoutGroup(ConventionKey.Settings)] [SerializeField] private OrderInvokeCallback executeOrder;
       [FoldoutGroup(ConventionKey.Settings)] public TriggerCallback2D onTriggerEnter;
       [FoldoutGroup(ConventionKey.Settings)] public TriggerCallback2D onTriggerExit;
       [FoldoutGroup(ConventionKey.Settings)] public CollisionCallback2D onCollisionEnter;
       [FoldoutGroup(ConventionKey.Settings)] public CollisionCallback2D onCollisionExit;


        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!XynokUtility.PhysicUtils.IsLayer(other, interactableLayer)) return;

            onTriggerEnter.Invoke(other, executeOrder);
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (!XynokUtility.PhysicUtils.IsLayer(other, interactableLayer)) return;

            onTriggerExit.Invoke(other, executeOrder);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (!XynokUtility.PhysicUtils.IsLayer(other, interactableLayer)) return;

            onCollisionEnter.Invoke(other, executeOrder);
        }

        private void OnCollisionExit2D(Collision2D other)
        {
            if (!XynokUtility.PhysicUtils.IsLayer(other, interactableLayer)) return;
            onCollisionExit.Invoke(other, executeOrder);
        }
    }
}