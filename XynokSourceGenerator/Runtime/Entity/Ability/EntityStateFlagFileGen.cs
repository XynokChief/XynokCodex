using Microsoft.CodeAnalysis;
using XynokSourceGenerator.Core.Const;
using XynokSourceGenerator.Utils.Extensions;

namespace XynokSourceGenerator.Runtime.Entity.Ability
{
    public class EntityStateFlagFileGen : AEntityAbilityFileGen
    {
        protected override string FileName => $"{EntityName}_StateFlag";
        protected override string TemplatePath => TxtPath.ENTITY_STATE_FLAG;

        protected override void OnInit()
        {
            base.OnInit();
            AppendFlag();
        }

        void AppendFlag()
        {
            var members = ((INamedTypeSymbol)StateSymbol).GetEnumMembers();
            int count = 1;
            AppendBody($"None = 0,");
            foreach (var member in members)
            {
                if (member == "None") continue;
                AppendBody($"{member} = {count},");
                count *= 2;
            }
        }
    }
}