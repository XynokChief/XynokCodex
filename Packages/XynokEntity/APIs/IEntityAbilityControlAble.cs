namespace XynokEntity.APIs
{
    public interface IEntityAbilityControlAble
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