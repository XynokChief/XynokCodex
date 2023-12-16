using XynokConvention.Data.Saver.APIs;
using XynokEntity.Ability;

namespace XynokEntity.Data.APIs
{
    /// <summary>
    /// pure data of entity, can be saved to disk
    /// </summary>
    public interface IEntityData : ISaveAble
    {
        /// <summary>
        /// unique id of entity
        /// </summary>
        int EntityId { get; }
        EntityAbilityCollection Abilities { get; }
        
    }

   
}