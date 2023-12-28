using System;
using Sirenix.OdinInspector;
using UnityEngine;
using XynokConvention.APIs;
using XynokSourceGenerator.Entities;


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

    [Title("Run","",TitleAlignments.Centered)]
    [Serializable]
    public class Run : ACharacterAbility, IAction
    {
        protected override void OnInit()
        {
        }

        protected override void OnExecute()
        {
            Debug.Log($"{owner.Resource.ResourceId} is running");
        }

        protected override void OnInterrupted()
        {
        }

        protected override void OnDispose()
        {
        }

        public override void Reset()
        {
        }

        public void Invoke()
        {
            Execute();
        }

        public void AddListener(Action action)
        {
        }

        public void RemoveListener(Action action)
        {
        }
    }

    public class Batman : ACharacterMono
    {
        protected virtual string title => "Batman";

        protected virtual string subTitle => "Batman entity";

        private void Start()
        {
            SetDependency(Resource);
        }
    }
}