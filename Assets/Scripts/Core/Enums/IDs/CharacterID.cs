using Core.Enums.Data;
using XynokSourceGenerator;

namespace Core.Enums.IDs
{
    /* last gen :
     -entity: 8B0A9482
     -api: 3DE452D4
     -data: 7D29F40C

     */
    
    [EntityStateMachineBehavior(typeof(CharacterStatType), typeof(CharacterStateType), typeof(CharacterTriggerType),"Assets/Scripts/Core/Generated/Character")]
    [EntityAbilityMaker(typeof(CharacterStatType), typeof(CharacterStateType), typeof(CharacterTriggerType))]
    [EntityMaker(typeof(CharacterStatType), typeof(CharacterStateType), typeof(CharacterTriggerType))]
    public enum CharacterID
    {
        None = 0,
    }


    public enum CharacterStateType
    {
        Idling,
        Attacking,
        Running,
    }

    public enum CharacterTriggerType
    {
        ForceRun,
        ForceAttack,
        
    }
}