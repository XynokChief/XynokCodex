#if UNITY_EDITOR
using Sirenix.OdinInspector;
using UnityEditor.Animations;
using UnityEngine;
using XynokConvention;


namespace XynokEntity.AnimPhasing.Editor
{
    /// <summary>
    /// bao gồm các hàm tiện ích để custom animator trên editor <inheritdoc cref="https://docs.unity3d.com/ScriptReference/Animations.AnimatorController.html"/>
    /// </summary>
    public class AnimatorEditor : MonoBehaviour
    {
        public Animator animator;
        private AnimatorController controller;

        public AnimatorController Controller
        {
            get
            {
                if (controller == null)
                    controller = animator.runtimeAnimatorController as AnimatorController;
                return controller;
            }
        }

        #region Erasers

        [FoldoutGroup(ConventionKey.Erasers)]
        [Button, GUIColor(Colors.Orange)]
        public void RemoveState(AnimationClip clip, int layerIndex)
        {
            RemoveState(clip.name, layerIndex);
        }

        [FoldoutGroup(ConventionKey.Erasers)]
        [Button, GUIColor(Colors.Orange)]
        public void RemoveState(string stateName, int layerIndex)
        {
            var state = GetAnimatorState(stateName, layerIndex);
            if (state == null) return;
            var stateMachineRoot = Controller.layers[layerIndex].stateMachine;
            stateMachineRoot.RemoveState(state);
        }


        [FoldoutGroup(ConventionKey.Erasers)]
        [Button, GUIColor(Colors.Orange)]
        public void RemoveStateMachine(string stateMachineName, int layerIndex)
        {
            var stateMachine = GetStateMachine(stateMachineName, layerIndex);
            if (stateMachine == null) return;
            var stateMachineRoot = Controller.layers[layerIndex].stateMachine;
            stateMachineRoot.RemoveStateMachine(stateMachine);
        }


        [FoldoutGroup(ConventionKey.Erasers)]
        [Button, GUIColor(Colors.Red)]
        public void RemoveLayer(int layerIndex)
        {
            if (Controller.layers.Length <= layerIndex)
            {
                Debug.LogWarning($"Layer {layerIndex} not exist");
                return;
            }

            Controller.RemoveLayer(layerIndex);
        }

        #endregion

        #region Creators

        [FoldoutGroup(ConventionKey.Creators)]
        [Button, GUIColor(Colors.Green)]
        public void AddLayer(string layerName)
        {
            Controller.AddLayer(layerName);
        }

        [FoldoutGroup(ConventionKey.Creators)]
        [Button, GUIColor(Colors.Green)]
        public void AddState(AnimationClip clip, int layerIndex = 0)
        {
            var state = AddState(clip.name, layerIndex);
            if (state == null) return;
            state.motion = clip;
        }

        [FoldoutGroup(ConventionKey.Creators)]
        [Button, GUIColor(Colors.Green)]
        public AnimatorStateMachine AddStateMachine(string stateMachineName, int layerIndex = 0)
        {
            if (ExistStateMachine(stateMachineName, layerIndex))
            {
                Debug.LogWarning($"State Machine {stateMachineName} already exist");
                return null;
            }

            var stateMachineRoot = Controller.layers[layerIndex].stateMachine;
            var stateMachine = stateMachineRoot.AddStateMachine(stateMachineName);
            return stateMachine;
        }

        [FoldoutGroup(ConventionKey.Creators)]
        [Button, GUIColor(Colors.Green)]
        public AnimatorState AddState(string stateName, int layerIndex = 0)
        {
            if (ExistState(stateName, layerIndex))
            {
                Debug.LogWarning($"State {stateName} already exist");
                return null;
            }

            var stateMachineRoot = Controller.layers[layerIndex].stateMachine;
            var state = stateMachineRoot.AddState(stateName);
            return state;
        }

        public bool ExistStateMachine(string stateMachineName, int layerIndex = 0)
        {
            var stateMachineRoot = Controller.layers[layerIndex].stateMachine;
            var stateMachines = stateMachineRoot.stateMachines;
            foreach (var state in stateMachines)
            {
                if (state.stateMachine.name == stateMachineName)
                    return true;
            }

            return false;
        }

        public bool ExistState(string stateName, int layerIndex = 0)
        {
            var stateMachine = Controller.layers[layerIndex].stateMachine;
            var states = stateMachine.states;
            foreach (var state in states)
            {
                if (state.state.name == stateName)
                    return true;
            }

            return false;
        }

        #endregion

        #region Configs

       // TODO: add more configs
        #endregion

        #region Internals

        AnimatorState GetAnimatorState(string stateName, int layerIndex = 0)
        {
            var stateMachine = Controller.layers[layerIndex].stateMachine;
            var states = stateMachine.states;
            foreach (var state in states)
            {
                if (state.state.name == stateName)
                    return state.state;
            }

            Debug.LogWarning($"State {stateName} at layer {layerIndex} does not exist");
            return null;
        }

        AnimatorStateMachine GetStateMachine(string stateMachineName, int layerIndex = 0)
        {
            var stateMachineRoot = Controller.layers[layerIndex].stateMachine;
            var stateMachines = stateMachineRoot.stateMachines;
            foreach (var state in stateMachines)
            {
                if (state.stateMachine.name == stateMachineName)
                    return state.stateMachine;
            }

            Debug.LogWarning($"State Machine {stateMachineName} at layer {layerIndex} does not exist");
            return null;
        }

        #endregion
    }
}
#endif