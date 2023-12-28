namespace XynokEntity.AnimPhasing.Data
{
    public enum RangeMilestone
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
        /// Active something like hitbox, etc
        /// </summary>
        Cast = 1,

        /// <summary>
        /// cast anim skill, attack, etc
        /// </summary>
        Perform = 2,

        /// <summary>
        /// recovery, end animation
        /// </summary>
        Exit = 3,
    }
}