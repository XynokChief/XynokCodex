using System;
using System.Linq;
using Sirenix.OdinInspector;
using UnityEngine;
using XynokConvention.APIs;
using XynokSourceGenerator.Entities;
using XynokSourceGenerator.Entities.APIs;


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
    }

    public class Batman : ACharacterMono
    {
        [Header("Batman")]
        public Animator animator;


        private void Start()
        {
            SetDependency(Resource);
            // InitBehaviorsStateMachine();
        }

        void InitBehaviorsStateMachine()
        {
            var behavs = animator.GetBehaviours<StateMachineBehaviour>().OfType<IInjectable<ICharacter>>();
            foreach (var behav in behavs)
            {
                behav.SetDependency(this);
            }
        }

        [Button]
        void Test()
        {
           
        }
    }
}