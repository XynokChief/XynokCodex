using Sirenix.OdinInspector;
using UnityEditor;
using UnityEngine;

namespace Runtime
{
    public class TestAnimBeha : MonoBehaviour
    {
        public AnimationClip clip;

        [Button]
        void Test(float time = .5f)
        {
            AnimationUtility.SetAnimationEvents(clip, new AnimationEvent[1]
            {
                new AnimationEvent
                {
                    functionName = nameof(AnimEvent),
                    time = time,
                    stringParameter = "Hello"
                }
            });
            string result= "";
            result += $"{clip.name}'s duration: {clip.length}\n";
            result += $"{clip.name}'s frame rate: {clip.frameRate}\n";
            Debug.Log(result);
        }
        
        void AnimEvent(string message)
        {
            Debug.Log(message);
        }
    }
}