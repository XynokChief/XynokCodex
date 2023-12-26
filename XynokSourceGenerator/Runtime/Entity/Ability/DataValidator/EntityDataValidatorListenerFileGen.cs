using XynokSourceGenerator.Core.Const;

namespace XynokSourceGenerator.Runtime.Entity.Ability.DataValidator
{
    public class EntityDataValidatorListenerFileGen : AEntityAbilityFileGen
    {
        protected override string FileName => $"{EntityName}_DataValidatorListener";
        protected override string TemplatePath => TxtPath.ENTITY_DATA_VALIDATOR_LISTENER;

        protected override void Scopes()
        {
            AppendScope(StatSymbol.ContainingNamespace.ToString());
            AppendScope(StateSymbol.ContainingNamespace.ToString());
        }
    }
}