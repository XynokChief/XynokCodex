using System;
using Sirenix.OdinInspector;
using XynokConvention;
using XynokEntity.Enums;


namespace XynokEntity.AnimPhasing.Data
{
    [Serializable]
    public class AnimOverriderData
    {
        [HorizontalGroup] [HideLabel] [ValueDropdown(nameof(GetOverriderList))]
        public string name = "???";

        [HorizontalGroup] [HideLabel] public AnimOverrideHandlerType handler;


#if UNITY_EDITOR

        private static string[] GetOverriderList =>
            XynokInput.Settings.Input.EmbedInputMap.Instance.GetInputActions(ConventionKey.PlayerInputMap);
#endif
    }
}