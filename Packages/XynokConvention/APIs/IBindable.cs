namespace XynokConvention.APIs
{
    public interface IBindable<out T>
    {
        event System.Action<T> OnChanged;
    }

    public interface IBindableDeeper<out T> : IBindable<T>
    {
        event System.Action<T, T, T> OnDeepChanged;
    }
}