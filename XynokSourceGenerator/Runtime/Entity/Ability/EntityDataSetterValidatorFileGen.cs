using XynokSourceGenerator.Core.Const;

namespace XynokSourceGenerator.Runtime.Entity.Ability
{
    public class EntityDataSetterValidatorFileGen: AEntityAbilityFileGen
    {
        protected override string FileName => $"{EntityName}_DataSetterValidator";
        protected override string TemplatePath => TxtPath.ENTITY_DATA_SETTER_VALIDATOR;
        
        protected override void Scopes()
        {
            AppendScope(StatSymbol.ContainingNamespace.ToString());
            AppendScope(StateSymbol.ContainingNamespace.ToString());
            AppendScope(TriggerSymbol.ContainingNamespace.ToString());
        }
         
    }
}