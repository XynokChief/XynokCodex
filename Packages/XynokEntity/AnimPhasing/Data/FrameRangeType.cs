namespace XynokEntity.AnimPhasing.Data
{
    public enum FrameRangeType
    {
        /// <summary>
        /// start enter animation
        /// </summary>
        Intro = 0,
        
        /// <summary>
        /// cast anim skill, attack, etc
        /// </summary>
        Perform = 1,
        
        /// <summary>
        /// recovery, end animation
        /// </summary>
        Outro = 2,
    }
}