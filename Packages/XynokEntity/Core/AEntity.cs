using System;
using UnityEngine;
using XynokEntity.APIs;
using XynokEntity.Data.APIs;

namespace XynokEntity.Core
{
    /// <summary>
    /// Entity dạng class thuần
    /// </summary>
    [Serializable]
    public abstract class AEntity : IEntity
    {
        [SerializeReference] private IEntityResource _resource;
        public IEntityResource Resource => _resource;

        public void SetDependency(IEntityResource dependency)
        {
            Dispose();
            if (dependency == null)
            {
                Debug.LogError($"[{GetType().Name}]:dependency is null");
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