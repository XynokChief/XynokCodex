using Core.Enums.Data;
using XynokSourceGen;

namespace Core.Enums.IDs
{
    [EntityMaker(typeof(CharacterAbilityType), typeof(CharacterStatType), typeof(CharacterStateType),
        typeof(CharacterTriggerType))]
    public enum CharacterID
    {
        None = 0,
    }

    public enum CharacterAbilityType
    {
    }

 

    public enum CharacterStateType
    {
    }

    public enum CharacterTriggerType
    {
    }
}