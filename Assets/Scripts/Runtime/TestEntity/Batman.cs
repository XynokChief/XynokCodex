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

    [TypeInfoBox("Run Ability")]
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

        private void Start()
        {
            SetDependency(Resource);
        }

        public void LogTest(string message)
        {
            Debug.Log(message);
        }
    }
}