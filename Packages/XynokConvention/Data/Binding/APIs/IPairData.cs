namespace XynokConvention.Data.Binding.APIs
{
    public interface IPairData<out T>
    {
        int HashKey { get; }
        T Data { get; }
    }
}