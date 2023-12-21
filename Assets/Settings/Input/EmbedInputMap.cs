using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using XynokUtils;

namespace XynokInput.Settings.Input
{
    [CreateAssetMenu(fileName = "EmbedInputMap", menuName = "Xynok/Input/EmbedInputMap")]
    public class EmbedInputMap : ScriptableObject
    {
        [SerializeField] private InputActionAsset inputActionAsset;
        [SerializeField] private TextAsset t4Generator;
        [ReadOnly] public string[] inputMaps;
        [ReadOnly] public string[] inputActions;
#if UNITY_EDITOR
        public static EmbedInputMap Instance =>
            XynokUtility.ScriptableObj.GetInstanceOfSo<EmbedInputMap>("Xynok/Input/EmbedInputMap");

        [Button]
        public void Reload()
        {
            inputMaps = GetAllInputMaps();
            inputActions = GetAllInputActions();
            AssetDatabase.ImportAsset(AssetDatabase.GetAssetPath(t4Generator));
        }
#endif

        public string[] GetAllInputMaps()
        {
            string[] result = new string[inputActionAsset.actionMaps.Count];
            for (int i = 0; i < inputActionAsset.actionMaps.Count; i++)
            {
                result[i] = inputActionAsset.actionMaps[i].name;
            }

            return result;
        }


        public string[] GetAllInputActions()
        {
            List<string> result = new();
            for (int i = 0; i < inputActionAsset.actionMaps.Count; i++)
            {
                var map = inputActionAsset.actionMaps[i];

                foreach (var action in map.actions)
                {
                    if (!result.Contains(action.name)) result.Add(action.name);
                }
            }

            return result.ToArray();
        }
    }
}