using Core.Enums.Data;
using XynokSourceGenerator;

namespace Core.Enums.IDs
{
    [EntityMaker( typeof(CharacterStatType), typeof(CharacterStateType), typeof(CharacterTriggerType))] // last gen : EF3B5361
    public enum CharacterID
    {
        None = 0,
    }

    
    public enum CharacterStateType
    {
    }

    public enum CharacterTriggerType
    {
    }
}