namespace XynokSourceGenerator.Core.Const
{
    public class TxtPath
    {
       private const string Prefix = "XynokSourceGenerator.Template";
       private const string Suffix = ".txt";
       
       // Entity
       public const string AENTITY = Prefix + ".Entity.AEntity" + Suffix;
       public const string ENTITY_DATA = Prefix + ".Entity.EntityData" + Suffix;
       public const string ENTITY_API = Prefix + ".Entity.EntityAPIs" + Suffix;
       
       // Ability
       public const string AENTITY_ABILITY = Prefix + ".Entity.Ability.AEntityAbility" + Suffix;
       public const string ENTITY_STATE_FLAG = Prefix + ".Entity.Ability.EntityStateFlag" + Suffix;
       
       // Module có sẵn
       public const string ENTITY_ANIMATOR_BINDER = Prefix + ".Entity.Ability.Module.AnimatorBinder" + Suffix;
       public const string ENTITY_ABILITY_EXECUTOR_ON_UPDATE = Prefix + ".Entity.Ability.Module.EntityAbilityExecutorOnUpdate" + Suffix;
       public const string ENTITY_ABILITY_EXECUTOR_ON_DATA_CHANGED = Prefix + ".Entity.Ability.Module.EntityAbilityExecutorOnDataChanged" + Suffix;
       
       // Ability.DataSetter
       public const string ENTITY_DATA_SETTER = Prefix + ".Entity.Ability.DataSetter.EntityDataSetter" + Suffix;
       public const string ENTITY_DATA_SETTER_VALIDATOR = Prefix + ".Entity.Ability.DataSetter.EntityDataSetterValidator" + Suffix; // có thay đổi thì set 
       public const string ENTITY_DATA_VALUE_SETTER_VALIDATOR = Prefix + ".Entity.Ability.DataSetter.EntityDataValueSetterValidator" + Suffix; // check điều kiện trước khi set
       public const string ENTITY_DATA_VALUE_SETTER_VALIDATOR_CONTAINER = Prefix + ".Entity.Ability.DataSetter.EntityDataValueSetterValidatorContainer" + Suffix; // check điều kiện trước khi set
       
       // Ability.DataValidator
       public const string ENTITY_DATA_VALIDATOR = Prefix + ".Entity.Ability.DataValidator.EntityDataValidator" + Suffix;
       public const string ENTITY_DATA_VALIDATOR_CONTAINER = Prefix + ".Entity.Ability.DataValidator.EntityDataValidatorContainer" + Suffix;
       
       // Ability.DataTracker
       public const string ENTITY_DATA_CHANGED_DETECTOR = Prefix + ".Entity.Ability.DataTracker.EntityDataChangedDetector" + Suffix; // emit event callback khi có thay đổi của 1 số loại data
       public const string ENTITY_DATA_RELATIONSHIP = Prefix + ".Entity.Ability.DataTracker.EntityDataRelationship" + Suffix;
       public const string ENTITY_DATA_RELATIONSHIP_CONTAINER = Prefix + ".Entity.Ability.DataTracker.EntityDataRelationshipContainer" + Suffix;
    }
}