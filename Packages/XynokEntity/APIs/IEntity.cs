using XynokConvention.APIs;
using XynokEntity.Data.APIs;

namespace XynokEntity.APIs
{
    /// <summary>
    /// đại diện cho một thực thể trong quá trình runtime
    /// </summary>
    public interface IEntity: IInjectable<IEntityResource>
    {
        IEntityResource Resource { get; }
    }
}