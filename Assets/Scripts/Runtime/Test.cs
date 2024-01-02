using Sirenix.OdinInspector;
using XynokConvention;
using XynokEntity.AnimPhasing;
using XynokEntity.AnimPhasing.Data;
using XynokSourceGenerator.Entities.APIs;
using XynokSourceGenerator.Entities.StateMachine;

namespace Runtime
{
    public class Test : EntityAnimatorFrameDataContainer<ICharacter>
    {
        [FoldoutGroup(ConventionKey.Settings)]
        [Button(ButtonSizes.Medium), GUIColor(Colors.Purple)]
        void InitAnimatorStateMachine()
        {
#if UNITY_EDITOR
            var controller = animator.runtimeAnimatorController as UnityEditor.Animations.AnimatorController;
            var behaviors = controller.GetBehaviours<CharacterAnimatorStateMachine>();
            foreach (var behavior in behaviors)
            {
                DestroyImmediate(behavior, true);
            }


            for (int i = 0; i < controller.layers.Length; i++)
            {
                var layerIndex = i;
                var layer = controller.layers[layerIndex];
                var behaviour = controller.layers[layerIndex].stateMachine
                    .AddStateMachineBehaviour<CharacterAnimatorStateMachine>();
                var layerData = new AnimLayer
                {
                    layerIndex = layerIndex,
                };
            }

            var result = controller.layers[0].stateMachine.AddStateMachineBehaviour<CharacterAnimatorStateMachine>();


            //result.frameDataContainer = this;
#endif
        }
    }
}