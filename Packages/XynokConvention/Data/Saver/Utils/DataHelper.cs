using Newtonsoft.Json;
using UnityEngine;

namespace XynokConvention.Data.Saver.Utils
{
    public class DataHelper
    {
        private static JsonSerializerSettings _jsonSerializerSettings = new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
        };

        public static void SaveData<T>(T data, string key, JsonSerializerSettings settings = null, bool logTest = false)
        {
            var json = JsonConvert.SerializeObject(data, Formatting.Indented,
                settings ?? _jsonSerializerSettings);

            PlayerPrefs.SetString(key, json);

            PlayerPrefs.Save();

            if (logTest) Debug.Log($"DATA SAVED - <color=cyan>{key}</color>: {json}");
        }

        public static T LoadSavedData<T>(string key, JsonSerializerSettings settings = null, bool logTest = false)
        {
            var json = PlayerPrefs.GetString(key);

            if (logTest) Debug.Log($"DATA LOADED - <color=cyan>{key}</color>: {json}");

            return JsonConvert.DeserializeObject<T>(json, settings ?? _jsonSerializerSettings);
        }
    }
}