using XynokSourceGenerator.Core.Const;

namespace XynokSourceGenerator.Runtime.Entity.StateMachine
{
    public class EntityAbilityInitAnimStateMachineFileGen: AEntityStateMachineDataBehaviorFileGen
    {
        protected override string FileName  => $"A{EntityName}_Ability_Init_Anim_State_Machine";
        protected override string TemplatePath => TxtPath.ENTITY_ABILITY_INIT_ANIM_STATE_MACHINE;
    }
}