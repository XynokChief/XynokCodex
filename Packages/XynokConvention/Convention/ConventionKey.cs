namespace XynokConvention
{
    public static class ConventionKey
    {
        /*--------------------------------------------- Odin titles ---------------------------------------------*/
        public const string PlayerInputMap = "Player";
        public const string Settings = "settings";
        public const string Events = "events";
        public const string CurrentValue = "CurrentValue";
        public const string Key = "key";
        public const string State = "state";
        public const string Conditions = "Conditions";
        public const string SetDataValue = "set value for";
        public const string Erasers = "Erasers";
        public const string Creators = "Creators";
        public const string AnimClipData = "clip data";
        public const string Frames = "frames";
        
        /*--------------------------------------------- Anim events ---------------------------------------------*/
        public const string AnimStartEvent = "StartEvent"; // event at frame 0
        public const string AnimEndEvent = "EndEvent"; // event at anim end
        public const string AnimEvent = "AnimEvent"; // event at frame range
    
        /*--------------------------------------------- Encode conventions ---------------------------------------------*/
        public const char Separator = ':';

        /// <summary>
        /// quy ước mã hóa thông tin: {param1}:{param2}:{param3}:{param4}:{param5} ...
        /// </summary>
        public static string GetStrInterpolatedBySeparator(string[] parameters)
        {
            var result = "";

            for (int i = 0; i < parameters.Length; i++)
            {
                var str = string.IsNullOrEmpty(parameters[i]) ? "null" : parameters[i];
                var separator = i >= parameters.Length - 1 ? "" : Separator.ToString();
                result += $"{str}{separator}";
            }

            return result;
        }
    }
}