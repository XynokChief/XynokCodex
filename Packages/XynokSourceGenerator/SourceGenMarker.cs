using System;

namespace XynokSourceGenerator
{
    public class SourceGenMarker
    {
    }

    #region Entity

    /// <summary>
    /// use this attribute to mark an enum as a factory for a group of entities (e.g. HeroA, HeroB, etc.)
    /// suffix the enum name with "Id" or "Ids" or "ID" or "IDs"(e.g. EffectIDs, HeroIds, etc.)
    /// </summary>
    /// <typeparam name="statGroup">`statGroup` must be an enum.
    ///statGroup is the group of stats that this entity has (e.g. health, mana, etc.)
    /// </typeparam>
    /// <typeparam name="stateGroup">`stateGroup` must be an enum.
    ///stateGroup is the group of states that this entity has (e.g. stunned, poisoned, etc.)
    /// </typeparam>
    /// <typeparam name="triggerGroup">`triggerGroup` must be an enum.
    ///triggerGroup is the group of triggers that this entity has be (e.g. forceAttack, forceJump, etc.)
    /// </typeparam>
    [AttributeUsage(AttributeTargets.Enum)]
    public class EntityMakerAttribute : Attribute
    {
        public Type statGroup;
        public Type stateGroup;
        public Type triggerGroup;

        public EntityMakerAttribute(Type statGroup, Type stateGroup, Type triggerGroup)
        {
            this.statGroup = statGroup;
            this.stateGroup = stateGroup;
            this.triggerGroup = triggerGroup;
        }
    }

    /// <summary>
    /// gen sẵn abstract ability cho thực thể
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum)]
    public class EntityAbilityMakerAttribute : Attribute
    {
        public Type statGroup;
        public Type stateGroup;
        public Type triggerGroup;

        public EntityAbilityMakerAttribute(Type statGroup, Type stateGroup, Type triggerGroup)
        {
            this.statGroup = statGroup;
            this.stateGroup = stateGroup;
            this.triggerGroup = triggerGroup;
        }
    }


    /// <summary>
    /// sử dụng cho các thực thể nào muốn ability của chúng là dạng Goap
    /// </summary>
    [AttributeUsage(AttributeTargets.Enum)]
    public class EntityAbilityGoapMakerAttribute : Attribute
    {
    }

    #endregion
}