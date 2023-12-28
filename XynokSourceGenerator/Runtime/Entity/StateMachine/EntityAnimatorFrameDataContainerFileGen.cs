using XynokSourceGenerator.Core.Const;

namespace XynokSourceGenerator.Runtime.Entity.StateMachine
{
    public class EntityAnimatorFrameDataContainerFileGen: AEntityStateMachineDataBehaviorFileGen
    {
        protected override string FileName  => $"{EntityName}AnimatorFrameDataContainer";
        protected override string TemplatePath => TxtPath.ENTITY_ANIMATOR_FRAME_DATA_CONTAINER;
        

        public override string HintName(bool hasHash = true)
        {
            return FileName;
        }
    }
}