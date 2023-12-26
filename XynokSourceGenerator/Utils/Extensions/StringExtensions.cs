using System;
using System.Security.Cryptography;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace XynokSourceGenerator.Utils.Extensions
{
    public static class StringExtensions
    {
        private static HashAlgorithm _algorithm = SHA256.Create();
        public static string EnsureEndsWith(this string source, string suffix)
        {
            if (source.EndsWith(suffix))  return source;
            return source + suffix;
        }
        
        public static string FormatAsCSharpCode(this string source)
        {
            return CSharpSyntaxTree.ParseText(source).GetRoot().NormalizeWhitespace().ToFullString();
        }
        

        public static int GetPersistentHashCode(this string str) {
            byte[] hash256;
            int hash = 0;

            hash256 = _algorithm.ComputeHash(Encoding.UTF8.GetBytes(str));
            for (int i = 0; i < hash256.Length; i+=4) {
                hash ^= BitConverter.ToInt32(hash256, i);
            }

            return hash;
        }

        public static string GetPersistentHashString(this string str) {
            return String.Format("{0:X8}", GetPersistentHashCode(str));
        }
    }
}