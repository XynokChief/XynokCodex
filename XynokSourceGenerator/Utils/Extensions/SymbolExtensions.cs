using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;

namespace XynokSourceGenerator.Utils.Extensions
{
    public static class SymbolExtensions
    {
        public static bool IsEnum(this ISymbol symbol)
        {
            return symbol.Kind == SymbolKind.NamedType && ((INamedTypeSymbol)symbol).TypeKind == TypeKind.Enum;
        }

        public static IEnumerable<string> GetEnumMembers(this INamedTypeSymbol enumSymbol)
        {
            return enumSymbol.GetMembers().Where(member => member.Kind == SymbolKind.Field)
                .Select(member => member.Name);
        }

        public static AttributeData GetAttribute(this ISymbol symbol, string attributeName)
        {
            string compare = attributeName;

            var attributes = symbol.GetAttributes();

            for (int i = 0; i < attributes.Length; i++)
            {
                var attributeClass = attributes[i].AttributeClass;

                if (attributeClass == null) continue;
                if (attributeClass.Name != compare) continue;

                return attributes[i];
            }

            return null;
        }

        public static string[] GetAttributeArgumentTypes(this AttributeData attributeData)
        {
            var constructorArguments = attributeData.ConstructorArguments;

            string[] args = new string[attributeData.ConstructorArguments.Length];

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

        public static string[] GetAttributeArgumentTypes(this ISymbol symbol, string attributeName)
        {
            var attributeData = symbol.GetAttribute(attributeName);
            if (attributeData == null) return null;
            return attributeData.GetAttributeArgumentTypes();
        }
    }
}