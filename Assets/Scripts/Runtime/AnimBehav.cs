using UnityEngine;
using UnityEngine.Animations;

namespace Runtime
{
    public class AnimBehav: StateMachineBehaviour
    {
        public GameObject obj;
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Debug.Log($"{obj.name} is exiting {stateInfo}");
        }
        
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            Debug.Log($"{obj.name} is entering {stateInfo}");
        }

        public override void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
        {
            Debug.Log($"{obj.name} is IK {stateInfo}");
        }

        public override void OnStateMachineEnter(Animator animator, int stateMachinePathHash)
        {
           Debug.Log($"{obj.name} is entering state machine {stateMachinePathHash}");
        }


        public override void OnStateMachineExit(Animator animator, int stateMachinePathHash)
        {
            Debug.Log($"{obj.name} is exiting state machine {stateMachinePathHash}");
        }
    }
}