using UnityEngine;
using XynokEntity.APIs;

namespace XynokEntity.AnimPhasing
{
    public class EntityAnimatorStateMachine<T> : StateMachineBehaviour where T : IEntity
    {
        public string[] stateNames;
        public EntityAnimatorFrameDataContainer<T> frameDataContainer;
        
        // Note: anim event luôn dc gọi trước hàm này
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