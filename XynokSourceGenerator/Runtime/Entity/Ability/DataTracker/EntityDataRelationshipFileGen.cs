using XynokSourceGenerator.Core.Const;

namespace XynokSourceGenerator.Runtime.Entity.Ability.DataTracker
{
    public class EntityDataRelationshipFileGen: AEntityAbilityFileGen
    {
        protected override string FileName => $"{EntityName}_DataRelationship";
        protected override string TemplatePath => TxtPath.ENTITY_DATA_RELATIONSHIP;
        
        protected override void Scopes()
        {
            AppendScope(StatSymbol.ContainingNamespace.ToString());
            AppendScope(StateSymbol.ContainingNamespace.ToString());
        }
    }
}