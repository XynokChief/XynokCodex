using XynokSourceGenerator.Core.Const;

namespace XynokSourceGenerator.Runtime.Entity.Ability.DataValidator
{
    public class EntityDataValidatorFileGen : AEntityAbilityFileGen
    {
        protected override string FileName => $"{EntityName}_DataValidator";
        protected override string TemplatePath => TxtPath.ENTITY_DATA_VALIDATOR;

        protected override void Scopes()
        {
            AppendScope(StatSymbol.ContainingNamespace.ToString());
            AppendScope(StateSymbol.ContainingNamespace.ToString());
        }
    }
}