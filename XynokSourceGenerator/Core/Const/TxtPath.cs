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
    }
}