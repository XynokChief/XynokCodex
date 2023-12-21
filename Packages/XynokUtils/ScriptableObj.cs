using System.IO;
using UnityEngine;

namespace XynokUtils
{
    public partial class XynokUtility
    {
        public static class ScriptableObj
        {
            public static T GetInstanceOfSo<T>(string hintCreate)
                where T : ScriptableObject
            {
#if UNITY_EDITOR
                string typeName = typeof(T).Name;
                var guidList = UnityEditor.AssetDatabase.FindAssets($"t:{typeName}");
                T so;
                if (guidList.Length > 0)
                {
                    var path = Path.Combine(
                        Path.GetDirectoryName(UnityEditor.AssetDatabase.GUIDToAssetPath(guidList[0])) ?? string.Empty,
                        typeName + ".asset");

                    so = UnityEditor.AssetDatabase.LoadAssetAtPath<T>(path);
                    if (so != null) return so;
                }
#endif

                Debug.LogError(
                    $"not found instance of {typeName} \n To Create:<color=cyan> Right Click > Create > {hintCreate}</color>");
                return null;
            }
        }
    }
}