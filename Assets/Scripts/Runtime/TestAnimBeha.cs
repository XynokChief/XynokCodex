using UnityEngine;
using UnityEngine.Animations;

namespace Runtime
{
    public class TestAnimBeha: StateMachineBehaviour
    {
        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex,
            AnimatorControllerPlayable controller)
        {
           var clipInfo = animator.GetCurrentAnimatorClipInfo(layerIndex); 
           Debug.Log(clipInfo[0].clip.name);
          
        }
    }
}