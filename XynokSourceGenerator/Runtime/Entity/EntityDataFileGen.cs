using XynokSourceGenerator.Core.Const;

namespace XynokSourceGenerator.Runtime.Entity
{
    public class EntityDataFileGen : AEntityFileGen
    {
        protected override string FileName => $"{EntityName}_Data";
        protected override string TemplatePath => TxtPath.ENTITY_DATA;
        
       
    }
}