using XynokSourceGenerator.Core.Const;

namespace XynokSourceGenerator.Runtime.Entity.Ability
{
    public class EntityCurrentStateValidatorFileGen: AEntityAbilityFileGen
    {
        protected override string FileName   => $"{EntityName}_StateValidator";
        protected override string TemplatePath => TxtPath.ENTITY_STATE_VALIDATOR;
    }
}