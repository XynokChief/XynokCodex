using XynokSourceGenerator.Core.Const;

namespace XynokSourceGenerator.Runtime.Entity.Ability.DataValidator
{
    public class EntityDataValidatorListenerExecutorContainerFileGen : AEntityAbilityFileGen
    {
        protected override string FileName => $"{EntityName}_DataValidatorListenerExecutorContainer";
        protected override string TemplatePath => TxtPath.ENTITY_DATA_VALIDATOR_LISTENER_EXECUTOR_CONTAINER;
    }
}

