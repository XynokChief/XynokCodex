using System;
using Sirenix.OdinInspector;
using UnityEngine;
using XynokConvention.APIs;
using XynokSourceGenerator.Entities;
using XynokSourceGenerator.Entities.Data;

namespace Runtime
{
    [Serializable]
    public class CanRun : IValidator
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
       

        protected override void OnInit()
        {
        }

        protected override void OnExecute()
        {
            Debug.Log($"{owner.Resource.ResourceId} is running");
        }

        protected override void OnDispose()
        {
        }

        public override void Reset()
        {
        }
    }

    public class Batman : ACharacterMono
    {
        [Header("Batman")]
        public Animator animator;


        private void Start()
        {
            SetDependency(Resource);
        }

        [Button]
        void Test()
        {
           
        }
    }
}