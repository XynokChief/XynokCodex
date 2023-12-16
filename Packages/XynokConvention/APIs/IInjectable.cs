using System;

namespace XynokConvention.APIs
{
    public interface IInjectable<in T> : IDisposable
    {
        void SetDependency(T dependency);
    }

    /// <summary>
    /// in case of generic dependency
    /// </summary>
    public interface IInjectableGeneric<in T> : IDisposable
    {
        void SetDependency<TD>(TD dependency) where TD : T;
    }
}