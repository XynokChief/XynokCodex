namespace XynokEntity.AnimPhasing.Data
{
    public enum FrameRangeEventType
    {
        Start = 0,
        End = 1,
    }

    public enum FrameRangeType
    {
        /// <summary>
        /// start enter animation
        /// </summary>
        Enter = 0,

        /// <summary>
        /// Active hitbox, etc
        /// </summary>
        Cast = 1,

        /// <summary>
        /// cast vfx of skill, attack, etc
        /// </summary>
        Perform = 2,

        /// <summary>
        /// recovery, end animation
        /// </summary>
        Exit = 3,

        /// <summary>
        /// can be interrupted at this range
        /// </summary>
        Overridable = 4,
    }
}