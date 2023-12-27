using XynokSourceGenerator.Core.Const;
using XynokSourceGenerator.Utils;
using XynokSourceGenerator.Utils.Extensions;

namespace XynokSourceGenerator.Core.SourceGen
{
    public abstract class AFileGenContent
    {
        public string Scope = "";
        public string Body = "";
        protected abstract string FileName { get; }
        protected abstract string TemplatePath { get; }
        protected abstract void OnInit();
        public virtual string HintName(bool hasHash = true) => GetHintName(hasHash);

        private bool _isInited;

        /// <summary>
        /// must use generic because of the template cannot be cast to printer
        /// </summary>
        public string Generate<T>(T prop) where T : AFileGenContent
        {
            Init();

            var template = FileHelper.GetEmbededResource(TemplatePath);
            var content = Printer.Generate(prop, template);
            return content;
        }

        protected  string FilterName(string name)
        {
            foreach (var suffix in Keyword.groupSuffixs)
            {
                name = name.Replace(suffix, "");
            }

            return name;
        }
        void Init()
        {
            if (_isInited) return;
            _isInited = true;
            OnInit();
        }

        string GetHintName(bool hasHash = true)
        {
            Init();

            var suffix = ".g";
            var source = $"{FileName.Replace(".", "_")}";

            if (!hasHash) return $"{source}{suffix}";

            var hash = $"{source.GetPersistentHashString()}";
            
            return $"{source}_{hash}{suffix}";
        }

        public void AppendScope(string scopeStr)
        {
            var scope = $"using {scopeStr};";

            if (Scope.Contains(scope)) return;

            Scope += $"\n{scope}";
        }

        public void AppendBody(string content)
        {
            Body += $"\n{content}";
        }
    }
}