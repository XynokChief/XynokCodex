using XynokSourceGenerator.Core.Const;

namespace XynokSourceGenerator.Runtime.Entity.Ability
{
    public class EntityDataValueSetterValidatorContainerFileGen: AEntityAbilityFileGen
    {
        protected override string FileName => $"{EntityName}_Data_Value_Setter_Validator_Container";
        protected override string TemplatePath => TxtPath.ENTITY_DATA_VALUE_SETTER_VALIDATOR_CONTAINER;

        protected override void Scopes()
        {
            // AppendScope(StatSymbol.ContainingNamespace.ToString());
            // AppendScope(StateSymbol.ContainingNamespace.ToString());
        }
    }
}