using XynokSourceGenerator.Core.Const;

namespace XynokSourceGenerator.Runtime.Entity.Ability.DataSetter
{
    public class EntityDataSetterFileGen: AEntityAbilityFileGen
    {
        protected override string FileName => $"{EntityName}_DataSetter";
        protected override string TemplatePath => TxtPath.ENTITY_DATA_SETTER;

        protected override void Scopes()
        {
            AppendScope(StatSymbol.ContainingNamespace.ToString());
            AppendScope(StateSymbol.ContainingNamespace.ToString());
            AppendScope(TriggerSymbol.ContainingNamespace.ToString());
        }
    }
}