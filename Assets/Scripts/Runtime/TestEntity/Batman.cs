using System;
using Sirenix.OdinInspector;
using UnityEngine;
using XynokConvention.APIs;
using XynokEntity.AnimPhasing.Data;
using XynokEntity.APIs;
using XynokInput.Settings.Input;
using XynokSourceGenerator.Entities;


namespace Runtime.TestEntity
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
    public class Run : ACharacterAbility, IAction, IActionAnimOverrider
    {
        public InputActionID AnimOverrideActName => InputActionID.Fire;

        public Action AnimOverrideAct => Invoke;

        public event Action OnRequestAnimOverride;

        protected override void OnInit()
        {
        }

        [Button]
        protected override void OnExecute()
        {
            OnRequestAnimOverride?.Invoke();
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
            Debug.Log($"{owner.Resource.ResourceId} is running");
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
        public AnimLayer layer;

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