using System.Linq;
using Microsoft.CodeAnalysis;
using XynokSourceGenerator.Core.SourceGen;
using XynokSourceGenerator.Utils.Extensions;

namespace XynokSourceGenerator.Runtime.Entity.StateMachine
{
    [Generator]
    public class
        EntityStateMachineGenerator : ASourceGen<EntityStateMachineBehaviorAttribute,
        AEntityStateMachineDataBehaviorFileGen>
    {
        protected override void Execute(GeneratorExecutionContext context,
            AttributeSyntaxReceiver<EntityStateMachineBehaviorAttribute> syntaxReceiver)
        {
            foreach (var enumDeclarationSyntax in syntaxReceiver.Enums)
            {
                var model = context.Compilation.GetSemanticModel(enumDeclarationSyntax.SyntaxTree);
                var symbol = model.GetDeclaredSymbol(enumDeclarationSyntax);
                if (symbol == null) continue;

                var attributeData = symbol.GetAttribute(nameof(EntityStateMachineBehaviorAttribute));

                var argumentTypes = attributeData.GetAttributeArgumentTypes();

                if (argumentTypes.Length < 1) continue;

                // get args from attribute
                var entitySymbol = context.Compilation.GetSymbolsWithName(symbol.Name).First();
                var statSymbol = context.Compilation.GetSymbolsWithName(argumentTypes[0]).First();
                var stateSymbol = context.Compilation.GetSymbolsWithName(argumentTypes[1]).First();
                var triggerSymbol = context.Compilation.GetSymbolsWithName(argumentTypes[2]).First();
                var genPath = attributeData.ConstructorArguments[3].Value.ToString();

                var aStateMachineDataBehaviorFileGen = new AEntityStateMachineDataBehaviorFileGen
                {
                    EntitySymbol = entitySymbol,
                    StatSymbol = statSymbol,
                    StateSymbol = stateSymbol,
                    TriggerSymbol = triggerSymbol,
                };
                var stateMachineDataFileGen = new EntityStateMachineDataFileGen
                {
                    EntitySymbol = entitySymbol,
                    StatSymbol = statSymbol,
                    StateSymbol = stateSymbol,
                    TriggerSymbol = triggerSymbol,
                };

                var entityAbilityInitAnimStateMachineFileGen = new EntityAbilityInitAnimStateMachineFileGen
                {
                    EntitySymbol = entitySymbol,
                    StatSymbol = statSymbol,
                    StateSymbol = stateSymbol,
                    TriggerSymbol = triggerSymbol,
                };


                var entityAnimatorFrameDataContainerFileGen = new EntityAnimatorFrameDataContainerFileGen
                {
                    EntitySymbol = entitySymbol,
                    StatSymbol = statSymbol,
                    StateSymbol = stateSymbol,
                    TriggerSymbol = triggerSymbol,
                };
                var entityAnimatorStateMachineFileGen = new EntityAnimatorStateMachineFileGen
                {
                    EntitySymbol = entitySymbol,
                    StatSymbol = statSymbol,
                    StateSymbol = stateSymbol,
                    TriggerSymbol = triggerSymbol,
                };
                var entityAbilityInitAnimActionOverriderFileGen = new EntityAbilityInitAnimActionOverriderFileGen
                {
                    EntitySymbol = entitySymbol,
                    StatSymbol = statSymbol,
                    StateSymbol = stateSymbol,
                    TriggerSymbol = triggerSymbol,
                };

                GenCode(context, aStateMachineDataBehaviorFileGen);
                GenCode(context, stateMachineDataFileGen);
                GenCode(context, entityAbilityInitAnimStateMachineFileGen);
                
                
                WriteFile(genPath, entityAnimatorFrameDataContainerFileGen);
                WriteFile(genPath, entityAnimatorStateMachineFileGen);
                
                GenCode(context, entityAbilityInitAnimActionOverriderFileGen);
            }
        }
    }
}