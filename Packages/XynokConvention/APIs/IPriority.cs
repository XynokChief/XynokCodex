namespace XynokConvention.APIs
{
    public interface IPriority<out T>
    {
        T Priority { get; }
    }

    public interface IPriorityInt : IPriority<int>
    {
    }
}