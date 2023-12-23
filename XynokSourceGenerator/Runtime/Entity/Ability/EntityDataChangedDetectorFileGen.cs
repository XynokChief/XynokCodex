using XynokSourceGenerator.Core.Const;

namespace XynokSourceGenerator.Runtime.Entity.Ability
{
    public class EntityDataChangedDetectorFileGen : AEntityAbilityFileGen
    {
        protected override string FileName => $"{EntityName}_DataChangedDetector";
        protected override string TemplatePath => TxtPath.ENTITY_DATA_CHANGED_DETECTOR;
    }
}