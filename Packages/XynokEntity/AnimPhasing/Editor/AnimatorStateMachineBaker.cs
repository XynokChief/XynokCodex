#if UNITY_EDITOR
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Animations;
using UnityEngine;
using XynokEntity.AnimPhasing.Data;

namespace XynokEntity.AnimPhasing.Editor
{
    public class AnimatorStateMachineBaker
    {
        private Animator animator;
        private AnimatorController controller;

        public AnimatorStateMachineBaker(Animator animator)
        {
            this.animator = animator;
            controller = animator.runtimeAnimatorController as AnimatorController;
        }

        public AnimLayer[] GetLayers()
        {
            var layers = new AnimLayer[controller.layers.Length];
            for (int i = 0; i < controller.layers.Length; i++)
            {
                int index = i;
                var layer = controller.layers[index];
                layers[i] = new AnimLayer
                {
                    layerIndex = index,
                    layerName = layer.name,
                    states = GetStates(layer)
                };
            }

            return layers;
        }

        IAnimState[] GetStates(AnimatorControllerLayer layer)
        {
            var result = new List<IAnimState>();

            // get normal states & blend trees
            for (int i = 0; i < layer.stateMachine.states.Length; i++)
            {
                var state = layer.stateMachine.states[i];
                result.Add(GetState(state.state));
            }

            // get sub state machines
            for (int i = 0; i < layer.stateMachine.stateMachines.Length; i++)
            {
                var stateMachine = layer.stateMachine.stateMachines[i];
                var stateName = stateMachine.stateMachine.name;
                result.Add(new SubStateMachineAnim
                {
                    stateName = stateName,
                    states = GetStates(stateMachine)
                });
            }

            return result.ToArray();
        }

        IAnimState[] GetStates(ChildAnimatorStateMachine stateMachine)
        {
            var result = new List<IAnimState>();
            
            // get normal states & blend trees
            for (int i = 0; i < stateMachine.stateMachine.states.Length; i++)
            {
                var state = stateMachine.stateMachine.states[i];
                result.Add(GetState(state.state));
            }

            // get sub state machines
            for (int i = 0; i < stateMachine.stateMachine.stateMachines.Length; i++)
            {
                var stateMachine2 = stateMachine.stateMachine.stateMachines[i];
                var stateName = stateMachine2.stateMachine.name;
                result.Add(new SubStateMachineAnim
                {
                    stateName = stateName,
                    states = GetStates(stateMachine2)
                });
            }

            return result.ToArray();
        }

        IAnimState GetState(AnimatorState state)
        {
            var name = state.name;
            if (state.motion is BlendTree blendTree)
            {
                return new BlendTreeAnimState
                {
                    stateName = name,
                    motionNames = GetMotions(blendTree).ToArray()
                };
            }

            return new NormalAnimState
            {
                stateName = name
            };
        }

        List<string> GetMotions(BlendTree blendTree)
        {
            var result = new List<string>();
            for (int i = 0; i < blendTree.children.Length; i++)
            {
                var child = blendTree.children[i];

                if (child.motion is BlendTree childBlendTree)
                {
                    result = result.Union(GetMotions(childBlendTree)).ToList();
                    continue;
                }

                var motionName = child.motion.name;
                if (!result.Contains(motionName)) result.Add(motionName);
            }

            return result;
        }
    }
}
#endif