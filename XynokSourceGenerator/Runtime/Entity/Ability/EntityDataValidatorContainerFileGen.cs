using XynokSourceGenerator.Core.Const;

namespace XynokSourceGenerator.Runtime.Entity.Ability
{
    public class EntityDataValidatorContainerFileGen: AEntityAbilityFileGen
    {
        protected override string FileName => $"{EntityName}_DataValidatorContainer";
        protected override string TemplatePath => TxtPath.ENTITY_DATA_VALIDATOR_CONTAINER;
        
        protected override void Scopes()
        {
            AppendScope(StatSymbol.ContainingNamespace.ToString());
            AppendScope(StateSymbol.ContainingNamespace.ToString());
            AppendScope(TriggerSymbol.ContainingNamespace.ToString());
        }
    }
}