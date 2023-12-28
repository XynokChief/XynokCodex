using UnityEngine;
using System;
using Sirenix.OdinInspector;
using UnityEngine.Events;
using XynokConvention.Data.Saver.APIs;
using XynokConvention.Patterns;

namespace XynokConvention.Data.Saver
{
   
    /// <summary>
    /// managed save & load data
    /// </summary>
    public class DataManager : ASingleton<DataManager>
    {
        [FoldoutGroup("Save & Load Event")] public UnityEvent onSave;
        [FoldoutGroup("Save & Load Event")] public UnityEvent onLoad;
        [Space(10)]
        [SerializeReference] protected ISaveAble[] savers = Array.Empty<ISaveAble>();

        protected override void Awake()
        {
            base.Awake();
            Load();
        }

        public T Get<T>() where T : ISaveAble
        {
            foreach (var saver in savers)
            {
                if (saver is T target) return target;
            }

            Debug.LogError($"[{GetType().Name}]: saver {typeof(T).Name} not found !");
            return default;
        }

        [HorizontalGroup("Split", 0.5f)]
        [Button(ButtonSizes.Medium), GUIColor(.7f, .2f, .96f)]
        public void Save()
        {
            onSave?.Invoke();
            foreach (var saver in savers)
            {
                saver?.Save();
            }
        }

        [HorizontalGroup("Split", 0.5f)]
        [Button(ButtonSizes.Medium), GUIColor(0.4f, 0.8f, 1)]
        public void Load()
        {
            onLoad?.Invoke();
            foreach (var saver in savers)
            {
                saver?.Load();
            }
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus) Save();
        }

        private void OnApplicationQuit()
        {
            Save();
        }
    }
}