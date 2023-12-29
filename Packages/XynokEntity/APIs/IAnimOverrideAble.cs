using System;
using XynokInput.Settings.Input;

namespace XynokEntity.APIs
{
    /// <summary>
    /// thường áp dụng cho các action đơn nhiệm, chạy trong 1 lần gọi
    /// </summary>
    public interface IAnimOverrideAble
    {
        void RegisterOverrider(IActionAnimOverrider overrider);
    }


    public interface IActionAnimOverrider
    {
        event Action OnRequestAnimOverride;
        InputActionID AnimOverrideActName { get; }
        Action AnimOverrideAct { get; }
    }
}