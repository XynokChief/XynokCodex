﻿using XynokSourceGenerator;

namespace Core.Enums.IDs
{
    /* last gen :
     -entity: 8B0A9482
     -api: 3DE452D4
     -data: 7D29F40C

     */
    
    [EntityStateMachineBehavior(typeof(CharacterStatType), typeof(CharacterStateType), typeof(CharacterTriggerType),"Assets/Scripts/Core/Generated/Character",true)]
    [EntityAbilityMaker(typeof(CharacterStatType), typeof(CharacterStateType), typeof(CharacterTriggerType))]
    [EntityMaker(typeof(CharacterStatType), typeof(CharacterStateType), typeof(CharacterTriggerType),true)]
    public enum CharacterID
    {
        None = 0,
    }
    public enum CharacterStatType
    {
        None = 0,
        Hp,
        MaxHp,
        Mana
    }

    public enum CharacterStateType
    {
        Idling,
        Attacking,
        Running,
        Equipped,
    }

    public enum CharacterTriggerType
    {
        ForceRun,
        ForceAttack,
        
    }
}