using XynokConvention.Data.Binding;

namespace XynokEntity.APIs
{
    public interface IItemEntity
    {
        BoolData BeUsing { get; }
    }
    
    public interface IItemOwner<T> where T : IItemEntity
    {
        T[] Items { get; set; }
    }
}