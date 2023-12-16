using UnityEngine;
using XynokEntity.APIs;
using XynokEntity.Data.APIs;

namespace XynokEntity.Core
{
    /// <summary>
    /// Entity dạng Gameobject
    /// </summary>
    public abstract class AMonoEntity : MonoBehaviour, IEntity
    {
        [SerializeReference] private IEntityResource _resource;
        public IEntityResource Resource => _resource;

        public void SetDependency(IEntityResource dependency)
        {
            Dispose();
            if (dependency == null)
            {
                Debug.LogError($"[{name} - {GetType().Name}]:dependency is null");
                return;
            }

            _resource = dependency;
            Init();
        }

        protected abstract void Init();
        protected abstract void OnDispose();

        public void Dispose()
        {
            OnDispose();
        }
    }
}