using XynokSourceGenerator.Core.Const;

namespace XynokSourceGenerator.Runtime.Entity.StateMachine
{
    public class AEntityStateMachineDataBehaviorFileGen : AEntityFileGen
    {
        protected override string FileName => $"A{EntityName}_State_Machine_Data_Behaviour";
        protected override string TemplatePath => TxtPath.AENTITY_STATE_MACHINE_DATA_BEHAVIOR;

        public string ItemCanOverrideAnimAction = "";
    }
}