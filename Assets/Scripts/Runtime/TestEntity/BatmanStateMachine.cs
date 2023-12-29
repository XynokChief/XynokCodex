using UnityEngine;
using XynokSourceGenerator.Entities.StateMachine;

namespace Runtime.TestEntity
{
    public class BatmanStateMachine : StateMachineBehaviour
    {
        public string[] stateNames;
        public CharacterAnimatorFrameDataContainer frameDataContainer;
        // Note: anim event luôn dc gọi trước
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            foreach (var state in stateNames)
            {
                if (!stateInfo.IsName(state)) continue;
                frameDataContainer.ResolveStateOnExit(state);
                break;
            }
        }
    }
}