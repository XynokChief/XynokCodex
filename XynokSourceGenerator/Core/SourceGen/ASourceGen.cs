using System;
using Microsoft.CodeAnalysis;

namespace XynokSourceGenerator.Core.SourceGen
{
    public abstract class ASourceGen<T1, T2> : ISourceGenerator
        where T1 : Attribute
        where T2 : AFileGenContent
    {
        public void Initialize(GeneratorInitializationContext context)
        {
            context.RegisterForSyntaxNotifications(() => new AttributeSyntaxReceiver<T1>());
        }

        public void Execute(GeneratorExecutionContext context)
        {
            if (context.SyntaxReceiver is not AttributeSyntaxReceiver<T1> syntaxReceiver) return;
            Execute(context, syntaxReceiver);
        }

        protected void GenCode(GeneratorExecutionContext context, T2 fileGen)
        {
            context.AddSource(fileGen.HintName(), fileGen.Generate(fileGen));
        }

        protected abstract void Execute(GeneratorExecutionContext context, AttributeSyntaxReceiver<T1> syntaxReceiver);
    }
}