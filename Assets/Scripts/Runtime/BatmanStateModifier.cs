using UnityEngine;
using XynokSourceGenerator.Entities.APIs;

namespace Runtime
{
    public class BatmanStateModifier: MonoBehaviour, ICharacterAbility
    {
        public void SetDependency(ICharacter dependency)
        {
            
        }

        public void Dispose()
        {
            
        }

        public void Execute()
        {
            throw new System.NotImplementedException();
        }

        public void Reset()
        {
            throw new System.NotImplementedException();
        }

        public ICharacter Owner { get; }
    }
}