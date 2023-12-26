using XynokSourceGenerator.Core.Const;

namespace XynokSourceGenerator.Runtime.Entity.Ability
{
    public class AEntityAbilityFileGen: AEntityFileGen
    {
        protected override string FileName  => $"{EntityName}_Ability";
        protected override string TemplatePath => TxtPath.AENTITY_ABILITY;

     
    }
}