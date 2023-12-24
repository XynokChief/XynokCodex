using UnityEngine;
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
        [Header("COLLISION SETTING")] [SerializeField]
        private LayerMask interactableLayer;

        [SerializeField] private OrderInvokeCallback executeOrder;
        public TriggerCallback2D onTriggerEnter;
        public TriggerCallback2D onTriggerExit;
        public CollisionCallback2D onCollisionEnter;
        public CollisionCallback2D onCollisionExit;


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