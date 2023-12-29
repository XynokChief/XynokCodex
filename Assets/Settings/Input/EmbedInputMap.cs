using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
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
        [ReadOnly] public InputMapData[] inputMapsData;
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
            InitAllInputMapsData();
            UnityEditor.AssetDatabase.ImportAsset(UnityEditor.AssetDatabase.GetAssetPath(t4Generator));
        }
#endif


        public string[] GetInputActions(string mapName)
        {
            return inputMapsData.First(e => e.mapName == mapName).actionNames;
        }

        void InitAllInputMapsData()
        {
            inputMapsData = new InputMapData[inputMaps.Length];
            for (int i = 0; i < inputMaps.Length; i++)
            {
                var map = inputActionAsset.FindActionMap(inputMaps[i]);
                inputMapsData[i] = new InputMapData
                {
                    mapName = inputMaps[i],
                    actionNames = new string[map.actions.Count]
                };
                for (int j = 0; j < map.actions.Count; j++)
                {
                    inputMapsData[i].actionNames[j] = map.actions[j].name;
                }
            }
        }

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