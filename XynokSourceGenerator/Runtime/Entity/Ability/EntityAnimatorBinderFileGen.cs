using XynokSourceGenerator.Core.Const;

namespace XynokSourceGenerator.Runtime.Entity.Ability
{
    public class EntityAnimatorBinderFileGen: AEntityAbilityFileGen
    {
        protected override string FileName => $"{EntityName}_AnimatorBinder";
        protected override string TemplatePath => TxtPath.ENTITY_ANIMATOR_BINDER;
        
        protected override void OnInit()
        {
            base.OnInit();
            AppendAnimatorBinder();
        }

        void AppendAnimatorBinder()
        {
          
        }
    }
}