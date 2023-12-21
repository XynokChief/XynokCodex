namespace XynokEntity.APIs
{
    public interface IControlAble
    {
        /// <summary>
        /// Execute the ability (logic only)
        /// </summary>
        void Execute();
            
        /// <summary>
        /// Reset the ability to its initial state
        /// </summary>
        void Reset();
    }
}