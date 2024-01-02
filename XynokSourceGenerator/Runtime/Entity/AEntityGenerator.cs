using System.Linq;
using Microsoft.CodeAnalysis;
using XynokSourceGenerator.Core.SourceGen;
using XynokSourceGenerator.Utils.Extensions;

namespace XynokSourceGenerator.Runtime.Entity
{
    [Generator]
    public class AEntityGenerator : ASourceGen<EntityMakerAttribute, AEntityFileGen>
    {
        protected override void Execute(GeneratorExecutionContext context,
            AttributeSyntaxReceiver<EntityMakerAttribute> syntaxReceiver)
        {
            foreach (var enumDeclarationSyntax in syntaxReceiver.Enums)
            {
                var model = context.Compilation.GetSemanticModel(enumDeclarationSyntax.SyntaxTree);
                var symbol = model.GetDeclaredSymbol(enumDeclarationSyntax);

                if (symbol == null) continue;

                var attributeData = symbol.GetAttribute(nameof(EntityMakerAttribute));
                var argumentTypes = attributeData.GetAttributeArgumentTypes();

                if (argumentTypes.Length < 1) continue;

                // get args from attribute
                var entitySymbol = context.Compilation.GetSymbolsWithName(symbol.Name).First();
                var statSymbol = context.Compilation.GetSymbolsWithName(argumentTypes[0]).First();
                var stateSymbol = context.Compilation.GetSymbolsWithName(argumentTypes[1]).First();
                var triggerSymbol = context.Compilation.GetSymbolsWithName(argumentTypes[2]).First();
                var hasItem = attributeData.ConstructorArguments[3].Value.ToString();

                var entityFileGen = new AEntityFileGen
                {
                    EntitySymbol = entitySymbol,
                    StatSymbol = statSymbol,
                    StateSymbol = stateSymbol,
                    TriggerSymbol = triggerSymbol,
                    HasItem = hasItem == "True" ? "" : "//"
                };

                var dataFileGen = new EntityDataFileGen
                {
                    EntitySymbol = entitySymbol,
                    StatSymbol = statSymbol,
                    StateSymbol = stateSymbol,
                    TriggerSymbol = triggerSymbol,
                    HasItem = hasItem == "True" ? "" : "//"
                };

                var apiFileGen = new EntityApiFileGen
                {
                    EntitySymbol = entitySymbol,
                    StatSymbol = statSymbol,
                    StateSymbol = stateSymbol,
                    TriggerSymbol = triggerSymbol,
                    HasItem = hasItem == "True" ? "" : "//"
                };
                var stateFileGen = new EntityStateFlagFileGen
                {
                    EntitySymbol = entitySymbol,
                    StatSymbol = statSymbol,
                    StateSymbol = stateSymbol,
                    TriggerSymbol = triggerSymbol
                };

                GenCode(context, entityFileGen);
                GenCode(context, dataFileGen);
                GenCode(context, apiFileGen);
                GenCode(context, stateFileGen);
            }
        }
    }
}