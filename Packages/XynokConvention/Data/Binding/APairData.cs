using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace XynokConvention.Data.Binding
{
    [Serializable]
    public class APairData<T1, T2> : APrimitiveData<T2>
        where T1 : Enum
    {
        [SerializeField] [HorizontalGroup] [HideLabel]
        private T1 key;

        private int _hashKey;

        public int HashKey
        {
            get
            {
                if (_hashKey == default) _hashKey = Animator.StringToHash(key.ToString());
                return _hashKey;
            }
        }

        public APairData(T1 key, T2 baseValue) : base(baseValue)
        {
            _hashKey = Animator.StringToHash(key.ToString());
            this.key = key;
        }

        public APairData()
        {
        }

        protected APairData(T2 baseValue) : base(baseValue)
        {
        }

       
    }
}