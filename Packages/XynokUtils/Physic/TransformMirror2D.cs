using UnityEngine;
using XynokConvention.Enums;

namespace XynokUtils.Physic
{
    public class TransformMirror2D : MonoBehaviour
    {
        [Header("Transform Mirror")] [SerializeField]
        protected GameObject target;

        [SerializeField] protected GameObject mirror;
        [SerializeField] protected UpdateMode updateMode = UpdateMode.FixedUpdate;
        [SerializeField] protected bool includeRotation = true;
        [SerializeField] protected bool includeScaleDirection = true;
        private Vector3 _originalMirrorScale;

        private void Start()
        {
            _originalMirrorScale = mirror.transform.localScale;
        }

        protected virtual void Update()
        {
            if (updateMode == UpdateMode.Update) Mirror();
        }

        protected virtual void FixedUpdate()
        {
            if (updateMode == UpdateMode.FixedUpdate) Mirror();
        }

        protected virtual void LateUpdate()
        {
            if (updateMode == UpdateMode.LateUpdate) Mirror();
        }

        void Mirror()
        {
            mirror.transform.position = target.transform.position;

            if (!includeRotation && !includeScaleDirection) return;

            var direction = target.transform.localScale.x > 0 ? 1 : -1;

            if (includeRotation)
            {
                mirror.transform.eulerAngles = target.transform.eulerAngles;
            }

            if (includeScaleDirection)
            {
                mirror.transform.localScale = new Vector3(direction * _originalMirrorScale.x, _originalMirrorScale.y,
                    _originalMirrorScale.z);
            }
        }
    }
}