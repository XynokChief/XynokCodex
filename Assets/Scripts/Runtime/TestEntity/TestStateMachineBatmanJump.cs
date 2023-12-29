using System;
using UnityEngine;
using XynokSourceGenerator.Entities.APIs;
using XynokSourceGenerator.Entities.StateMachine;

namespace Runtime
{
    [Serializable]
    public class StateData : ICharacterStateMachineData
    {
        public int test;
        public string hero;

        public void SetDependency(ICharacter dependency)
        {
            Debug.Log($"Init batman stateData");
        }

        public void Dispose()
        {
        }
    }

    public class TestStateMachineBatmanJump : ACharacterStateMachine<StateData>
    { 
        protected override void OnStateEnter()
        {
            Debug.Log($"Batman is entering state machine: {stateMachineData.test} - {stateMachineData.hero}");
        }

        protected override void OnStateExit()
        {
            Debug.Log($"Batman is exiting state machine: {stateMachineData.test} - {stateMachineData.hero}");
        }
    }
}