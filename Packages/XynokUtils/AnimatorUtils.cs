using UnityEngine;

namespace XynokUtils
{
    public partial class XynokUtility
    {
        public static class AnimatorUtils
        {
            public static bool ExistParam(Animator animator, string name, AnimatorControllerParameterType type)
            {
                var paramsArray = animator.parameters;
                foreach (var parameter in paramsArray)
                {
                    if (parameter.name == name && parameter.type == type)
                    {
                        return true;
                    }
                }

                return false;
            }

            public static void ClearAllParams(Animator animator)
            {
#if !UNITY_EDITOR
            Debug.LogWarning($"[{nameof(ClearAllParams)}]: this method only works in editor mode!");
#endif

#if UNITY_EDITOR

                if (animator == null)
                {
                    Debug.LogError($"[{nameof(ClearAllParams)}]: animator is null");
                    return;
                }

                if (animator.runtimeAnimatorController == null)
                {
                    Debug.LogError($"[{nameof(ClearAllParams)}]: animator controller is null");
                    return;
                }

                UnityEditor.Animations.AnimatorController animatorController =
                    animator.runtimeAnimatorController as UnityEditor.Animations.AnimatorController;

                if (animatorController == null)
                {
                    Debug.LogError(
                        $"[{nameof(ClearAllParams)}]: can not cast animator controller to UnityEditor.Animations.AnimatorController");
                    return;
                }

                for (int i = animatorController.parameters.Length - 1; i > -1; i--)
                {
                    int index = i;
                    animatorController.RemoveParameter(index);
                }
#endif
            }
        }
    }
}