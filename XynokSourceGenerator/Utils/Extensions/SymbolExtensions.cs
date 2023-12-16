using System;
using Microsoft.CodeAnalysis;

namespace XynokSourceGenerator.Utils.Extensions
{
    public static class SymbolExtensions
    {
        public static string GetScope( ISymbol symbol)
        {
            string typeScope = symbol.ContainingType?.ToString();
            string namespaceScope = symbol.ContainingNamespace?.ToString();
            string result = typeScope ?? (namespaceScope ?? "");

            return result;
        }

        public static string[] GetAttributeArgumentTypes(this ISymbol symbol, string attributeName)
        {
            string compare = attributeName;

            var attributes = symbol.GetAttributes();

            for (int i = 0; i < attributes.Length; i++)
            {
                var attributeClass = attributes[i].AttributeClass;

                if (attributeClass == null) continue;
                if (attributeClass.Name != compare) continue;

                var constructorArguments = attributes[i].ConstructorArguments;

                string[] args = new string[attributes[i].ConstructorArguments.Length];

                for (int j = 0; j < args.Length; j++)
                {
                    var value = constructorArguments[j].Value;
                    if (value != null)
                    {
                        string[] split = value.ToString().Split('.');
                        args[j] = split[split.Length - 1];
                    }
                }

                return args;
            }

            return Array.Empty<string>();
        }

    }
}