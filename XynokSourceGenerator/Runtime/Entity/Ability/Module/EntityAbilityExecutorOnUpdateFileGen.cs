using XynokSourceGenerator.Core.Const;

namespace XynokSourceGenerator.Runtime.Entity.Ability.Module
{
    public class EntityAbilityExecutorOnUpdateFileGen: AEntityAbilityFileGen
    {
        protected override string FileName  => $"{EntityName}_Ability_ExecutorOnUpdate";
        protected override string TemplatePath => TxtPath.ENTITY_ABILITY_EXECUTOR_ON_UPDATE;
    }
}