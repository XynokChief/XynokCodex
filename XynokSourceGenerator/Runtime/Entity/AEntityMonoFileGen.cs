using Microsoft.CodeAnalysis;
using XynokSourceGenerator.Core.Const;
using XynokSourceGenerator.Core.SourceGen;

namespace XynokSourceGenerator.Runtime.Entity
{
    public class AEntityMonoFileGen : AFileGenContent
    {
        protected override string FileName => $"{EntityName}_EntityMono";
        protected override string TemplatePath => TxtPath.AENTITY_MONO;

        private readonly string[] _suffixs = new[] { "ID", "IDs", "Id", "Ids", "Type", "Group", "Collection" };

        // replacements
        public string EntityName = "";
        public string EntityEnumName = "";
        public string StatName = "";
        public string StateName = "";
        public string TriggerName = "";

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

        void Scopes()
        {
            AppendScope(EntitySymbol.ContainingNamespace.ToString());
            AppendScope(StatSymbol.ContainingNamespace.ToString());
            AppendScope(StateSymbol.ContainingNamespace.ToString());
            AppendScope(TriggerSymbol.ContainingNamespace.ToString());
        }

        string FilterName(string name)
        {
            foreach (var suffix in _suffixs)
            {
                name = name.Replace(suffix, "");
            }

            return name;
        }
    }
}