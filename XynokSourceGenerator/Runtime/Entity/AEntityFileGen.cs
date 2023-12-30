using Microsoft.CodeAnalysis;
using XynokSourceGenerator.Core.Const;
using XynokSourceGenerator.Core.SourceGen;

namespace XynokSourceGenerator.Runtime.Entity
{
    /// <summary>
    /// tạo ra entity mono và class thuần
    /// </summary>
    public class AEntityFileGen : AFileGenContent
    {
        protected override string FileName => $"{EntityName}_Entity";
        protected override string TemplatePath => TxtPath.AENTITY;


        // replacements
        public string EntityName = "";
        public string EntityEnumName = "";
        public string StatName = "";
        public string StateName = "";
        public string TriggerName = "";
        public string HasItem = "//";

        // data
        public ISymbol EntitySymbol;
        public ISymbol StatSymbol;
        public ISymbol StateSymbol;
        public ISymbol TriggerSymbol;

        protected override void OnInit()
        {
            EntityName = FilterName(EntitySymbol.Name);
            EntityEnumName = EntitySymbol.Name;
            StatName = StatSymbol.Name;
            StateName = StateSymbol.Name;
            TriggerName = TriggerSymbol.Name;

            Scopes();
        }


        protected virtual void Scopes()
        {
           
        }
    }
}