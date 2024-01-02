using XynokSourceGenerator;

namespace Core.Enums.IDs
{
    [EntityAbilityMaker(typeof(CharacterStatType), typeof(CharacterStateType), typeof(CharacterTriggerType))]
    [EntityMaker(typeof(CharacterStatType), typeof(CharacterStateType), typeof(CharacterTriggerType))]
    public enum ItemID
    {
        None = 0,
        Sword,
        Shield,
        Bow,
    }
}