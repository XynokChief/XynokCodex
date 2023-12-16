using System.Linq;
using Microsoft.CodeAnalysis;
using XynokSourceGen;
using XynokSourceGenerator.Core.SourceGen;
using XynokSourceGenerator.Utils.Extensions;

namespace XynokSourceGenerator.Runtime.Entity
{
    [Generator]
    public class AEntityMonoGenerator : ASourceGen<EntityMakerAttribute, AEntityMonoFileGen>
    {
        protected override void Execute(GeneratorExecutionContext context,
            AttributeSyntaxReceiver<EntityMakerAttribute> syntaxReceiver)
        {
            foreach (var enumDeclarationSyntax in syntaxReceiver.Enums)
            {
                var model = context.Compilation.GetSemanticModel(enumDeclarationSyntax.SyntaxTree);
                var symbol = model.GetDeclaredSymbol(enumDeclarationSyntax);

                if (symbol == null) continue;

                var argumentTypes = symbol.GetAttributeArgumentTypes(nameof(EntityMakerAttribute));
                if (argumentTypes.Length < 1) continue;

                // get args from attribute
                var entitySymbol = context.Compilation.GetSymbolsWithName(symbol.Name).First();
                var abilitySymbol = context.Compilation.GetSymbolsWithName(argumentTypes[0]).First();
                var statSymbol = context.Compilation.GetSymbolsWithName(argumentTypes[1]).First();
                var stateSymbol = context.Compilation.GetSymbolsWithName(argumentTypes[2]).First();
                var triggerSymbol = context.Compilation.GetSymbolsWithName(argumentTypes[3]).First();

                var fileGen = new AEntityMonoFileGen
                {
                    EntitySymbol = entitySymbol,
                    AbilitySymbol = abilitySymbol,
                    StatSymbol = statSymbol,
                    StateSymbol = stateSymbol,
                    TriggerSymbol = triggerSymbol
                };

                GenCode(context, fileGen);
            }
        }
    }
}