using Core.Enums.Data;
using XynokSourceGenerator;

namespace Core.Enums.IDs
{
    [EntityMaker( typeof(CharacterStatType), typeof(CharacterStateType), typeof(CharacterTriggerType))] // last gen : 8B0A9482
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