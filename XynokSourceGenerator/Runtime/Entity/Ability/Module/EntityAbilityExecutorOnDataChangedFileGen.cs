using XynokSourceGenerator.Core.Const;

namespace XynokSourceGenerator.Runtime.Entity.Ability.Module
{
    public class EntityAbilityExecutorOnDataChangedFileGen: AEntityAbilityFileGen
    {
        protected override string FileName  => $"{EntityName}_Ability_ExecutorOnDataChanged";
        protected override string TemplatePath => TxtPath.ENTITY_ABILITY_EXECUTOR_ON_DATA_CHANGED;
    }
}