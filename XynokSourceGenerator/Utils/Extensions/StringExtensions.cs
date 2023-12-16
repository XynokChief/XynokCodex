using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace XynokSourceGenerator.Utils.Extensions
{
    public static class StringExtensions
    {
        public static string EnsureEndsWith(this string source, string suffix)
        {
            if (source.EndsWith(suffix))  return source;
            return source + suffix;
        }
        
        public static string FormatAsCSharpCode(this string source)
        {
            return CSharpSyntaxTree.ParseText(source).GetRoot().NormalizeWhitespace().ToFullString();
        }
        
      
    }
}