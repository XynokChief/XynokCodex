using System.Linq;
using Microsoft.CodeAnalysis;
using XynokSourceGenerator.Core.SourceGen;
using XynokSourceGenerator.Utils.Extensions;

namespace XynokSourceGenerator.Runtime.Entity.Ability
{
    [Generator]
    public class AEntityAbilityGenerator : ASourceGen<EntityAbilityMakerAttribute, AEntityAbilityFileGen>
    {
        protected override void Execute(GeneratorExecutionContext context,
            AttributeSyntaxReceiver<EntityAbilityMakerAttribute> syntaxReceiver)
        {
            foreach (var enumDeclarationSyntax in syntaxReceiver.Enums)
            {
                var model = context.Compilation.GetSemanticModel(enumDeclarationSyntax.SyntaxTree);
                var symbol = model.GetDeclaredSymbol(enumDeclarationSyntax);
                if (symbol == null) continue;

                var argumentTypes = symbol.GetAttributeArgumentTypes(nameof(EntityAbilityMakerAttribute));
                if (argumentTypes.Length < 1) continue;

                // get args from attribute
                var entitySymbol = context.Compilation.GetSymbolsWithName(symbol.Name).First();
                var statSymbol = context.Compilation.GetSymbolsWithName(argumentTypes[0]).First();
                var stateSymbol = context.Compilation.GetSymbolsWithName(argumentTypes[1]).First();
                var triggerSymbol = context.Compilation.GetSymbolsWithName(argumentTypes[2]).First();


                var abilityFileGen = new AEntityAbilityFileGen
                {
                    EntitySymbol = entitySymbol,
                    StatSymbol = statSymbol,
                    StateSymbol = stateSymbol,
                    TriggerSymbol = triggerSymbol
                };
                var stateFileGen = new EntityStateFlagFileGen
                {
                    EntitySymbol = entitySymbol,
                    StatSymbol = statSymbol,
                    StateSymbol = stateSymbol,
                    TriggerSymbol = triggerSymbol
                };
                
                var animatorBinderFileGen = new EntityAnimatorBinderFileGen
                {
                    EntitySymbol = entitySymbol,
                    StatSymbol = statSymbol,
                    StateSymbol = stateSymbol,
                    TriggerSymbol = triggerSymbol
                };
                
                var stateValidationFileGen = new EntityDataValidatorFileGen
                {
                    EntitySymbol = entitySymbol,
                    StatSymbol = statSymbol,
                    StateSymbol = stateSymbol,
                    TriggerSymbol = triggerSymbol
                };
                
                var dataRelationshipFileGen = new EntityDataRelationshipFileGen
                {
                    EntitySymbol = entitySymbol,
                    StatSymbol = statSymbol,
                    StateSymbol = stateSymbol,
                    TriggerSymbol = triggerSymbol
                };
            
                GenCode(context, abilityFileGen);
                GenCode(context, stateFileGen);
                GenCode(context, animatorBinderFileGen);
                GenCode(context, stateValidationFileGen);
                GenCode(context, dataRelationshipFileGen);
                
            }
        }
    }
}