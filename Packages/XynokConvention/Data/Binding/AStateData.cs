using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace XynokConvention.Data.Binding
{
    [Serializable]
    public class AStateData<T1> : BoolData where T1 : Enum
    {
        public AStateData(bool baseValue) : base(baseValue)
        {
            _hashKey = Animator.StringToHash(key.ToString());
        }

        public AStateData(T1 key, bool baseValue) : base(baseValue)
        {
            _hashKey = Animator.StringToHash(key.ToString());
            this.key = key;
        }

        public AStateData() : base(default)
        {
        }

        [SerializeField] [TableColumnWidth(150, Resizable = false)] [HorizontalGroup(ConventionKey.Key)] [HideLabel]
        private T1 key;

        private int _hashKey;
        public T1 Key => key;

        public int HashKey
        {
            get
            {
                if (_hashKey == default) _hashKey = Animator.StringToHash(key.ToString());
                return _hashKey;
            }
        }
    }
}