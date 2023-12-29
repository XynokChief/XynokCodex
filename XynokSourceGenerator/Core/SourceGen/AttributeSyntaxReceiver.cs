using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using XynokSourceGenerator.Utils;
using XynokSourceGenerator.Utils.Extensions;

namespace XynokSourceGenerator.Core.SourceGen
{
    /// <typeparam name="T">a type with name as marker attribute</typeparam>
    public class AttributeSyntaxReceiver<T> : ISyntaxReceiver where T : Attribute
    {
        public IList<ClassDeclarationSyntax> Classes { get; } = new List<ClassDeclarationSyntax>();
        public IList<EnumDeclarationSyntax> Enums { get; } = new List<EnumDeclarationSyntax>();
        public IList<InterfaceDeclarationSyntax> Interfaces { get; } = new List<InterfaceDeclarationSyntax>();


        private const string AttributeSuffix = "Attribute";

        public virtual void OnVisitSyntaxNode(SyntaxNode syntaxNode)
        {
            string compare = $"{typeof(T).Name}";
           

            if (syntaxNode is ClassDeclarationSyntax { AttributeLists: { Count: > 0 } } classDeclarationSyntax &&
                classDeclarationSyntax.AttributeLists
                    .Any(al => al.Attributes
                        .Any(a => a.Name.ToString().EnsureEndsWith(AttributeSuffix).Equals(compare))))
            {
                Classes.Add(classDeclarationSyntax);
            }

            if (syntaxNode is EnumDeclarationSyntax { AttributeLists: { Count: > 0 } } enums &&
                enums.AttributeLists
                    .Any(al => al.Attributes
                        .Any(a => a.Name.ToString().EnsureEndsWith(AttributeSuffix).Equals(compare))))
            {
                Enums.Add(enums);
            }
            
            if (syntaxNode is InterfaceDeclarationSyntax { AttributeLists: { Count: > 0 } } interfaces &&
                interfaces.AttributeLists
                    .Any(al => al.Attributes
                        .Any(a => a.Name.ToString().EnsureEndsWith(AttributeSuffix).Equals(compare))))
            {
                Interfaces.Add(interfaces);
            }
        }
    }
}