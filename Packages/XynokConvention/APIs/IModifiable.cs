using System;
using XynokConvention.Enums;

namespace XynokConvention.APIs
{
    public interface IModifier
    {
        ModifierType ModifierType { get; }
    }

    public interface IModifiable
    {
        void AddModifier(IModifier modifier, Action<bool> addResult);
        void RemoveModifier(IModifier modifier, Action<bool> removeResult);
        T[] GetModifiers<T>() where T : IModifier;
    }
}