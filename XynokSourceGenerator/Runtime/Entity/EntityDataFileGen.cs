using XynokSourceGenerator.Core.Const;

namespace XynokSourceGenerator.Runtime.Entity
{
    public class EntityDataFileGen : AEntityFileGen
    {
        protected override string FileName => $"{EntityName}_Data";
        protected override string TemplatePath => TxtPath.ENTITY_DATA;

        protected override void Scopes()
        {
            AppendScope(EntitySymbol.ContainingNamespace.ToString());
            AppendScope(StatSymbol.ContainingNamespace.ToString());
            AppendScope(StateSymbol.ContainingNamespace.ToString());
            AppendScope(TriggerSymbol.ContainingNamespace.ToString());
        }
    }
}