using XynokSourceGenerator.Core.Const;

namespace XynokSourceGenerator.Runtime.Entity.StateMachine
{
    public class EntityStateMachineDataFileGen : AEntityStateMachineDataBehaviorFileGen
    {
        protected override string FileName => $"{EntityName}_State_Machine_Data";
        protected override string TemplatePath => TxtPath.ENTITY_STATE_MACHINE_DATA;
    }
}