using System.Linq;
using Microsoft.CodeAnalysis;
using XynokSourceGenerator.Core.SourceGen;
using XynokSourceGenerator.Runtime.Entity.Ability.DataSetter;
using XynokSourceGenerator.Runtime.Entity.Ability.DataTracker;
using XynokSourceGenerator.Runtime.Entity.Ability.DataValidator;
using XynokSourceGenerator.Runtime.Entity.Ability.Module;
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
                
                var dataValidatorFileGen = new EntityDataValidatorFileGen
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
                
                var dataSetterFileGen = new EntityDataSetterFileGen
                {
                    EntitySymbol = entitySymbol,
                    StatSymbol = statSymbol,
                    StateSymbol = stateSymbol,
                    TriggerSymbol = triggerSymbol
                };
                
                var validatorContainerFileGen = new EntityDataValidatorContainerFileGen
                {
                    EntitySymbol = entitySymbol,
                    StatSymbol = statSymbol,
                    StateSymbol = stateSymbol,
                    TriggerSymbol = triggerSymbol
                };
                
                var dataRelationshipContainerFileGen = new EntityDataRelationshipContainerFileGen
                {
                    EntitySymbol = entitySymbol,
                    StatSymbol = statSymbol,
                    StateSymbol = stateSymbol,
                    TriggerSymbol = triggerSymbol
                };
                
                var valueSetterValidatorFileGen = new EntityDataValueSetterValidatorFileGen
                {
                    EntitySymbol = entitySymbol,
                    StatSymbol = statSymbol,
                    StateSymbol = stateSymbol,
                    TriggerSymbol = triggerSymbol
                };
                
                var valueSetterValidatorContainerFileGen = new EntityDataValueSetterValidatorContainerFileGen
                {
                    EntitySymbol = entitySymbol,
                    StatSymbol = statSymbol,
                    StateSymbol = stateSymbol,
                    TriggerSymbol = triggerSymbol
                };
                
                var dataChangedDetectorFileGen = new EntityDataChangedDetectorFileGen
                {
                    EntitySymbol = entitySymbol,
                    StatSymbol = statSymbol,
                    StateSymbol = stateSymbol,
                    TriggerSymbol = triggerSymbol
                };
                
                var abilityExecutorOnUpdateFileGen = new EntityAbilityExecutorOnUpdateFileGen
                {
                    EntitySymbol = entitySymbol,
                    StatSymbol = statSymbol,
                    StateSymbol = stateSymbol,
                    TriggerSymbol = triggerSymbol,
                };
                
                var abilityExecutorOnDataChangedFileGen = new EntityAbilityExecutorOnDataChangedFileGen
                {
                    EntitySymbol = entitySymbol,
                    StatSymbol = statSymbol,
                    StateSymbol = stateSymbol,
                    TriggerSymbol = triggerSymbol,
                };
                
                var dataValidatorListenerFileGen = new EntityDataValidatorListenerFileGen
                {
                    EntitySymbol = entitySymbol,
                    StatSymbol = statSymbol,
                    StateSymbol = stateSymbol,
                    TriggerSymbol = triggerSymbol,
                };
                
                var dataValidatorListenerExecutorFileGen = new EntityDataValidatorListenerExecutorFileGen
                {
                    EntitySymbol = entitySymbol,
                    StatSymbol = statSymbol,
                    StateSymbol = stateSymbol,
                    TriggerSymbol = triggerSymbol,
                };
                
                var dataValidatorListenerExecutorContainerFileGen = new EntityDataValidatorListenerExecutorContainerFileGen
                {
                    EntitySymbol = entitySymbol,
                    StatSymbol = statSymbol,
                    StateSymbol = stateSymbol,
                    TriggerSymbol = triggerSymbol,
                };
            
                GenCode(context, abilityFileGen);
                GenCode(context, stateFileGen);
                GenCode(context, animatorBinderFileGen);
                GenCode(context, dataValidatorFileGen);
                GenCode(context, dataRelationshipFileGen);
                GenCode(context, dataSetterFileGen);
                GenCode(context, validatorContainerFileGen);
                GenCode(context, dataRelationshipContainerFileGen);
                GenCode(context, valueSetterValidatorFileGen);
                GenCode(context, valueSetterValidatorContainerFileGen);
                GenCode(context, dataChangedDetectorFileGen);
                GenCode(context, abilityExecutorOnUpdateFileGen);
                GenCode(context, abilityExecutorOnDataChangedFileGen);
                GenCode(context, dataValidatorListenerFileGen);
                GenCode(context, dataValidatorListenerExecutorFileGen);
                GenCode(context, dataValidatorListenerExecutorContainerFileGen);
            }
        }
    }
}