using System;
using Core.Enums.IDs;
using XynokConvention.Data.Binding;
using XynokSourceGenerator.Entities;
using XynokSourceGenerator.Entities.APIs;

namespace Runtime.TestEntity.Item
{
    [Serializable]
    public class Sword : AItem, ICharacterItem
    {
        public bool IsUsing;
        public BoolData BeUsing => Resource.GetState(CharacterStateType.Equipped);
        public ICharacter Owner => _owner;
        private ICharacter _owner;

        public void SetDependency(ICharacter dependency)
        {
            Dispose();
            _owner = dependency;
            SetDependency(Resource);
        }

        public ICharacter ItemOwner { get; }
    }
}