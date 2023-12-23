namespace XynokConvention.APIs
{
    public interface IExecute
    {
        /// <summary>
        /// Execute the ability (logic only)
        /// </summary>
        void Execute();
    }

    public interface IReset
    {
        /// <summary>
        /// Reset the ability to its initial state
        /// </summary>
        void Reset();
    }
    public interface IControlAble : IExecute, IReset
    {
    }
}