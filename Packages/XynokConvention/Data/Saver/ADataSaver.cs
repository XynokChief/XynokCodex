using System;
using Newtonsoft.Json;
using UnityEngine;
using XynokConvention.Data.Saver.APIs;
using XynokConvention.Data.Saver.Utils;

namespace XynokConvention.Data.Saver
{
    /// <summary>
    /// quick implementation to save data
    /// </summary>
    /// <typeparam name="T">data for saving</typeparam>
    public abstract class ADataSaver<T> : ISaveAble
    {
        [SerializeField] private bool enableLogTest;
        [NonSerialized] protected T data;
        public abstract string SaveKey { get; }
        protected virtual JsonSerializerSettings JsonSerializerSettings => null;

        public void Save()
        {
            DataHelper.SaveData(data, SaveKey, JsonSerializerSettings, logTest: enableLogTest);
        }

        public void Load()
        {
            data = DataHelper.LoadSavedData<T>(SaveKey, JsonSerializerSettings, logTest: enableLogTest);
        }
    }
}