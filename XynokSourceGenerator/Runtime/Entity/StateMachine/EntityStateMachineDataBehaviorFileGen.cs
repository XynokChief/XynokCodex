using XynokSourceGenerator.Core.Const;

namespace XynokSourceGenerator.Runtime.Entity.StateMachine
{
    public class EntityStateMachineDataBehaviorFileGen: AEntityStateMachineDataBehaviorFileGen
    {
        protected override string FileName  => $"{EntityName}_State_Machine_Data_Behaviour";
        protected override string TemplatePath => TxtPath.ENTITY_STATE_MACHINE_DATA_BEHAVIOR;
        

        public override string HintName(bool hasHash = true)
        {
            return $"{EntityName}StateMachineDataBehavior";
        }
    }
}