using Sirenix.OdinInspector;
using UnityEngine;
using XynokEntity.AnimPhasing.Data;
using XynokEntity.AnimPhasing.Editor;

namespace XynokEntity.AnimPhasing.Test
{
    public class TestBakeAnim : MonoBehaviour
    {
        
        public Animator animator;
        
        public AnimLayer[] layers;

        [Button]
        void Bake()
        {
            AnimatorStateMachineBaker baker = new AnimatorStateMachineBaker(animator);
            layers = baker.GetLayers();
        }
    }
}