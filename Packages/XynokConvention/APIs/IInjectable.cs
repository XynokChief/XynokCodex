using System;

namespace XynokConvention.APIs
{
    public interface IInjectable<in T>: IDisposable
    {
        void Inject(T dependency);
    }
}