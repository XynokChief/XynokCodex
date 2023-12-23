using XynokSourceGenerator.Core.Const;

namespace XynokSourceGenerator.Runtime.Entity.Ability.DataSetter
{
    public class EntityDataValueSetterValidatorFileGen: AEntityAbilityFileGen
    {
        protected override string FileName => $"{EntityName}_Data_Value_Setter_Validator";
        protected override string TemplatePath => TxtPath.ENTITY_DATA_VALUE_SETTER_VALIDATOR;

        protected override void Scopes()
        {
            AppendScope(StatSymbol.ContainingNamespace.ToString());
            AppendScope(StateSymbol.ContainingNamespace.ToString());
        }
    }
}