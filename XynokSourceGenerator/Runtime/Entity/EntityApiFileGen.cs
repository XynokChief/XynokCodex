
using XynokSourceGenerator.Core.Const;

namespace XynokSourceGenerator.Runtime.Entity
{
    public class EntityApiFileGen: AEntityFileGen
    {
        protected override string FileName =>$"{EntityName}_APIs";
        protected override string TemplatePath => TxtPath.ENTITY_API;

        protected override void Scopes()
        {
        }
    }
}