namespace XynokEntity.Enums
{
    public enum AbilityExecuteValidatorType
    {
        /// <summary>
        /// detect if the owner's current state changed
        /// </summary>
        WhenOwnerStateChanged = 0,
        
        /// <summary>
        /// custom some data changed
        /// </summary>
        Custom = 1,
        
        /// <summary>
        /// always check validators on update mode
        /// </summary>
        Always = 2,
    }
}