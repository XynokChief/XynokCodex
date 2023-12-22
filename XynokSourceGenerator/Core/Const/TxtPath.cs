namespace XynokSourceGenerator.Core.Const
{
    public class TxtPath
    {
       private const string Prefix = "XynokSourceGenerator.Template";
       private const string Suffix = ".txt";
       
       public const string AENTITY = Prefix + ".Entity.AEntity" + Suffix;
       public const string ENTITY_DATA = Prefix + ".Entity.EntityData" + Suffix;
       public const string ENTITY_API = Prefix + ".Entity.EntityAPIs" + Suffix;
       
       public const string AENTITY_ABILITY = Prefix + ".Entity.Ability.AEntityAbility" + Suffix;
       public const string ENTITY_STATE_FLAG = Prefix + ".Entity.Ability.EntityStateFlag" + Suffix;
       public const string ENTITY_ANIMATOR_BINDER = Prefix + ".Entity.Ability.AnimatorBinder" + Suffix;
       public const string ENTITY_DATA_VALIDATOR = Prefix + ".Entity.Ability.EntityDataValidator" + Suffix;
       public const string ENTITY_DATA_VALIDATOR_CONTAINER = Prefix + ".Entity.Ability.EntityDataValidatorContainer" + Suffix;
       public const string ENTITY_DATA_RELATIONSHIP = Prefix + ".Entity.Ability.EntityDataRelationship" + Suffix;
       public const string ENTITY_DATA_SETTER = Prefix + ".Entity.Ability.EntityDataSetter" + Suffix;
       public const string ENTITY_DATA_RELATIONSHIP_CONTAINER = Prefix + ".Entity.Ability.EntityDataRelationshipContainer" + Suffix;
       public const string ENTITY_DATA_SETTER_VALIDATOR = Prefix + ".Entity.Ability.EntityDataSetterValidator" + Suffix; // có thay đổi thì set 
       public const string ENTITY_DATA_VALUE_SETTER_VALIDATOR = Prefix + ".Entity.Ability.EntityDataValueSetterValidator" + Suffix; // check điều kiện trước khi set
       public const string ENTITY_DATA_VALUE_SETTER_VALIDATOR_CONTAINER = Prefix + ".Entity.Ability.EntityDataValueSetterValidatorContainer" + Suffix; // check điều kiện trước khi set
    }
}