using UnityEngine;

namespace XynokEntity.AnimPhasing.Test
{
    public class TestStateMachine:StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Debug.Log($"OnStateEnter: {stateInfo.fullPathHash}");
        }
        
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Debug.Log($"OnStateExit: {stateInfo.fullPathHash}");
        }
    }
}