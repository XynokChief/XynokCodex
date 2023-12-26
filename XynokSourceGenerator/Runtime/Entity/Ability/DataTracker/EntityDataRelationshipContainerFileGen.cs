using XynokSourceGenerator.Core.Const;

namespace XynokSourceGenerator.Runtime.Entity.Ability.DataTracker
{
    public class EntityDataRelationshipContainerFileGen: AEntityAbilityFileGen
    {
        protected override string FileName => $"{EntityName}_DataRelationshipContainer";
        protected override string TemplatePath => TxtPath.ENTITY_DATA_RELATIONSHIP_CONTAINER;
        
        protected override void Scopes()
        {
            AppendScope(StatSymbol.ContainingNamespace.ToString());
            AppendScope(StateSymbol.ContainingNamespace.ToString());
            AppendScope(TriggerSymbol.ContainingNamespace.ToString());
        }
    }
}