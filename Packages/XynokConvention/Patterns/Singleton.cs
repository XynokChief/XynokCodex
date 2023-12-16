using System.Collections.Generic;
using UnityEngine;

namespace XynokConvention.Patterns
{
    public interface ISingleton
    {
    }

    public static class Singleton
    {
        private static List<ISingleton> _instances = new();

        public static void Join(ISingleton singleton)
        {
            if (_instances.Contains(singleton))
            {
                Debug.LogError($"singleton [{singleton.GetType().Name}] already exists!");
                return;
            }

            _instances.Add(singleton);
        }

        public static void Quit(ISingleton singleton)
        {
            var value = _instances.Remove(singleton);
            if (!value) Debug.LogWarning($"singleton [{singleton.GetType().Name}] not found to remove!");
        }

        public static T Get<T>() where T : ISingleton
        {
            foreach (var instance in _instances)
            {
                if (instance is T target)
                {
                    return target;
                }
            }

            Debug.LogError($"singleton [{typeof(T).Name}] not found!");
            return default;
        }
    }
}