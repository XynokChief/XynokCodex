using System;
using UnityEngine;
using XynokConvention.APIs;
using XynokSourceGenerator.Entities;

namespace Runtime
{
    [Serializable]
    public class CanRun : IValidate
    {
        public bool biggerThanZero;

        public bool IsValid()
        {
            return biggerThanZero;
        }
    }

    [Serializable]
    public class Run : ACharacterAbility
    {
        public float speed;

        protected override void Init()
        {
        }

        protected override void OnExecute()
        {
        }

        public override void Reset()
        {
        }

        public override void Dispose()
        {
        }
    }

    public class Batman : ACharacterMono
    {
        private void Start()
        {
            SetDependency(Resource);
        }
    }
}