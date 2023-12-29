using XynokSourceGenerator.Core.Const;
using XynokSourceGenerator.Utils.Extensions;

namespace XynokSourceGenerator.Utils
{
    public class Printer
    {

        public static string Generate<T>(T prop, string template)
        {
            var allFields = typeof(T).GetFields();
            for (int i = 0; i < allFields.Length; i++)
            {
                var fieldName = allFields[i].Name;
                if (!template.Contains($"{{{fieldName}}}")) continue;
                
                template = template.Replace($"{{{fieldName}}}",
                    allFields[i].GetValue(prop).ToString());
            }

            return Keyword.Author + template.FormatAsCSharpCode();
        }
    }
}