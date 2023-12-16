using System;
using Sirenix.OdinInspector;
using XynokConvention.APIs;

namespace XynokConvention.Data.Binding
{
    /// <summary>
    /// should be used for primitive types only
    /// </summary>
    /// <typeparam name="T">string, int, float,...</typeparam>
    [Serializable]
    public class APrimitiveData<T> : IBindableDeeper<T>
    {
        private T _baseValue;
        protected T lastValue;
        protected T currentValue;

        [ShowInInspector] [HorizontalGroup] public T BaseValue => _baseValue;

        [ShowInInspector] [HorizontalGroup] public T LastValue => lastValue;

        [ShowInInspector]
        [HorizontalGroup]
        public virtual T Value
        {
            get => currentValue;
            set
            {
                lastValue = currentValue;
                currentValue = value;
                EmitEventDeepChanged();
                EmitEventChanged();
            }
        }

        public APrimitiveData()
        {
            _baseValue = default;
            lastValue = _baseValue;
            currentValue = _baseValue;
        }

        public APrimitiveData(T baseValue)
        {
            _baseValue = baseValue;
            lastValue = _baseValue;
            currentValue = _baseValue;
        }

        public APrimitiveData(T baseValue, T lastValue, T currentValue)
        {
            _baseValue = baseValue;
            this.lastValue = lastValue;
            this.currentValue = currentValue;
        }

        public event Action<T> OnChanged;
        public event Action<T, T, T> OnDeepChanged;


        [Button]
        public void SetBaseValue(T value, bool emmitEvent = true)
        {
            _baseValue = value;
            lastValue = _baseValue;
            currentValue = _baseValue;
            if (emmitEvent) EmitEventDeepChanged();
            if (emmitEvent) EmitEventChanged();
        }


        public void SetCurrentValue(T value, bool emmitEvent = true)
        {
            lastValue = currentValue;
            currentValue = value;
            if (emmitEvent) EmitEventDeepChanged();
            if (emmitEvent) EmitEventChanged();
        }


        protected virtual void EmitEventChanged()
        {
            OnChanged?.Invoke(currentValue);
        }

        protected virtual void EmitEventDeepChanged()
        {
            OnDeepChanged?.Invoke(_baseValue, lastValue, currentValue);
        }
    }

    #region PrimitiveDataBinding

    [Serializable]
    public class StringData : APrimitiveData<string>
    {
        public StringData(string baseValue) : base(baseValue)
        {
        }
    }

    [Serializable]
    public class IntData : APrimitiveData<int>
    {
        public IntData(int baseValue) : base(baseValue)
        {
        }
    }

    [Serializable]
    public class FloatData : APrimitiveData<float>
    {
        public FloatData(float baseValue) : base(baseValue)
        {
        }
    }

    [Serializable]
    public class BoolData : APrimitiveData<bool>
    {
        public BoolData(bool baseValue) : base(baseValue)
        {
        }
    }

    [Serializable]
    public class DoubleData : APrimitiveData<double>
    {
        public DoubleData(double baseValue) : base(baseValue)
        {
        }
    }

    [Serializable]
    public class LongData : APrimitiveData<long>
    {
        public LongData(long baseValue) : base(baseValue)
        {
        }
    }

    [Serializable]
    public class ShortData : APrimitiveData<short>
    {
        public ShortData(short baseValue) : base(baseValue)
        {
        }
    }

    [Serializable]
    public class ByteData : APrimitiveData<byte>
    {
        public ByteData(byte baseValue) : base(baseValue)
        {
        }
    }

    [Serializable]
    public class CharData : APrimitiveData<char>
    {
        public CharData(char baseValue) : base(baseValue)
        {
        }
    }

    [Serializable]
    public class DecimalData : APrimitiveData<decimal>
    {
        public DecimalData(decimal baseValue) : base(baseValue)
        {
        }
    }

    [Serializable]
    public class SByteData : APrimitiveData<sbyte>
    {
        public SByteData(sbyte baseValue) : base(baseValue)
        {
        }
    }

    [Serializable]
    public class UIntData : APrimitiveData<uint>
    {
        public UIntData(uint baseValue) : base(baseValue)
        {
        }
    }

    [Serializable]
    public class ULongData : APrimitiveData<ulong>
    {
        public ULongData(ulong baseValue) : base(baseValue)
        {
        }
    }

    [Serializable]
    public class UShortData : APrimitiveData<ushort>
    {
        public UShortData(ushort baseValue) : base(baseValue)
        {
        }
    }

    [Serializable]
    public class DateTimeData : APrimitiveData<DateTime>
    {
        public DateTimeData(DateTime baseValue) : base(baseValue)
        {
        }
    }

    [Serializable]
    public class TimeSpanData : APrimitiveData<TimeSpan>
    {
        public TimeSpanData(TimeSpan baseValue) : base(baseValue)
        {
        }
    }

    [Serializable]
    public class GuidData : APrimitiveData<Guid>
    {
        public GuidData(Guid baseValue) : base(baseValue)
        {
        }
    }

    [Serializable]
    public class DateTimeOffsetData : APrimitiveData<DateTimeOffset>
    {
        public DateTimeOffsetData(DateTimeOffset baseValue) : base(baseValue)
        {
        }
    }

    [Serializable]
    public class Vector2Data : APrimitiveData<UnityEngine.Vector2>
    {
        public Vector2Data(UnityEngine.Vector2 baseValue) : base(baseValue)
        {
        }
    }

    [Serializable]
    public class Vector3Data : APrimitiveData<UnityEngine.Vector3>
    {
        public Vector3Data(UnityEngine.Vector3 baseValue) : base(baseValue)
        {
        }
    }

    [Serializable]
    public class Vector4Data : APrimitiveData<UnityEngine.Vector4>
    {
        public Vector4Data(UnityEngine.Vector4 baseValue) : base(baseValue)
        {
        }
    }

    [Serializable]
    public class QuaternionData : APrimitiveData<UnityEngine.Quaternion>
    {
        public QuaternionData(UnityEngine.Quaternion baseValue) : base(baseValue)
        {
        }
    }

    [Serializable]
    public class ColorData : APrimitiveData<UnityEngine.Color>
    {
        public ColorData(UnityEngine.Color baseValue) : base(baseValue)
        {
        }
    }

    [Serializable]
    public class BoundsData : APrimitiveData<UnityEngine.Bounds>
    {
        public BoundsData(UnityEngine.Bounds baseValue) : base(baseValue)
        {
        }
    }

    [Serializable]
    public class RectData : APrimitiveData<UnityEngine.Rect>
    {
        public RectData(UnityEngine.Rect baseValue) : base(baseValue)
        {
        }
    }

    #endregion
}