using XynokSourceGenerator.Core.Const;

namespace XynokSourceGenerator.Runtime.Entity.StateMachine
{
    public class EntityAnimatorStateMachineFileGen: AEntityStateMachineDataBehaviorFileGen
    {
        protected override string FileName  => $"{EntityName}AnimatorStateMachine";
        protected override string TemplatePath => TxtPath.ENTITY_ANIMATOR_STATE_MACHINE;
        

        public override string HintName(bool hasHash = true)
        {
            return FileName;
        }
    }
}