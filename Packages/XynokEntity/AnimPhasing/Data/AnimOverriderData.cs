using System;
using Sirenix.OdinInspector;
using XynokEntity.Enums;
using XynokInput.Settings.Input;


namespace XynokEntity.AnimPhasing.Data
{
    [Serializable]
    public class AnimOverriderData
    {
        [HorizontalGroup] [HideLabel] public InputActionID actionName;
        [HorizontalGroup] [HideLabel] public AnimOverrideHandlerType handler;
    }
}