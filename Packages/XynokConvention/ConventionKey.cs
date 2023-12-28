namespace XynokConvention
{
    public class ConventionKey
    {
        public const string PlayerInputMap = "Player";
        public const string Settings = "settings";
        public const string Events = "events";
        public const string CurrentState = "current state";
        public const string CurrentValue = "CurrentValue";
        public const string Key = "key";
        public const string State = "state";
        public const string Stat = "stat";
        public const string Conditions = "Conditions";
        public const string Value = "value";
        public const string Validator = "Validator";
        public const string AnimStartEvent = "StartEvent"; // start anim at frame 0
        public const string AnimEndEvent = "EndEvent"; // end anim at last frame
        public const string AnimEvent = "AnimEvent"; // event at frame range
        public const string AnimClipData = "clip data";
        public const string SetDataValue = "set value for";
        public const string Erasers = "Erasers";
        public const string Creators = "Creators";
        public const char Separator = ':';

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