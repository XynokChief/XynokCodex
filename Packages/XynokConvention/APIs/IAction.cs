using System;

namespace XynokConvention.APIs
{
    public interface IAction
    {
        void Invoke();
        void AddListener(Action action);
        void RemoveListener(Action action);
        
    }
}