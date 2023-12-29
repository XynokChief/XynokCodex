using XynokSourceGenerator.Core.Const;

namespace XynokSourceGenerator.Runtime.Entity.StateMachine
{
    public class EntityAbilityInitAnimActionOverriderFileGen: AEntityStateMachineDataBehaviorFileGen
    {
        protected override string FileName  => $"{EntityName}_Ability_Init_Anim_Action_Overrider";
        protected override string TemplatePath => TxtPath.ENTITY_ABILITY_INIT_ANIM_ACTION_OVERRIDER;
    }
}