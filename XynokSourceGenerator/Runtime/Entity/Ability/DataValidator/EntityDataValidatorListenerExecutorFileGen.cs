using XynokSourceGenerator.Core.Const;

namespace XynokSourceGenerator.Runtime.Entity.Ability.DataValidator
{
    public class EntityDataValidatorListenerExecutorFileGen: AEntityAbilityFileGen
    {
        protected override string FileName => $"{EntityName}_DataValidatorListenerExecutor";
        protected override string TemplatePath => TxtPath.ENTITY_DATA_VALIDATOR_LISTENER_EXECUTOR;
    }
}