using System;
using System.Linq;

namespace XynokUtils
{
    public partial class XynokUtility
    {
        public static class EnumUtils
        {
            public static T ParseEnum<T>(string value)
            {
                return (T)Enum.Parse(typeof(T), value, true);
            }

            public static T[] GetAllValuesOf<T>() where T : Enum
            {
                return Enum.GetValues(typeof(T)).Cast<T>().ToArray();
            }
        }
    }
}