using UnityEngine;

namespace XynokConvention.Patterns
{
    public abstract class ASingleton<T> : MonoBehaviour, ISingleton
    {
        public static T Instance;

        protected virtual void Awake()
        {
            Instance ??= gameObject.GetComponent<T>();
            Singleton.Join(this);
        }
    }
}