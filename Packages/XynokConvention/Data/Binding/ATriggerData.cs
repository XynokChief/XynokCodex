using System;
using XynokConvention.Data.Binding.APIs;

namespace XynokConvention.Data.Binding
{
    /// <summary>
    /// use for animation trigger
    /// </summary>
    /// <typeparam name="T">trigger param of animator</typeparam>
    [Serializable]
    public class ATriggerData<T> : APairData<T, bool>, ITriggerData
        where T : Enum
    {
        public Func<bool> canTrigger;

        public ATriggerData()
        {
        }

        protected ATriggerData(T key, bool baseValue) : base(key, baseValue)
        {
        }

        protected ATriggerData(bool baseValue) : base(baseValue)
        {
        }

        public override bool Value
        {
            get => currentValue;
            set
            {
                if (!canTrigger?.Invoke() ?? false)
                {
                    currentValue = false;
                    return;
                }

                lastValue = currentValue;
                currentValue = value;
                EmitEventChanged();
            }
        }

        public bool SetTrigger()
        {
            Value = true;
            return Value;
        }
    }
}