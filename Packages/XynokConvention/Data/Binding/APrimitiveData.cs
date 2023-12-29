using System;
using Sirenix.OdinInspector;
using UnityEngine;
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
        [TableColumnWidth(60)] [LabelWidth(120)] [FoldoutGroup(ConventionKey.Settings)] [SerializeField]
        protected T baseValue;

        [TableColumnWidth(60)] [LabelWidth(120)] [FoldoutGroup(ConventionKey.Settings)] [SerializeField]
        protected T lastValue;

        [TableColumnWidth(60)] [LabelWidth(120)] [FoldoutGroup(ConventionKey.Settings)] [SerializeField]
        protected T currentValue;

        [Tooltip("if true, the value will not be set if it is equal to the current value")]
        [TableColumnWidth(60)]
        [LabelWidth(120)]
        [FoldoutGroup(ConventionKey.Settings)]
        [SerializeField]
        protected bool duplicateCheck = true;

        public event Func<T, bool> CanChangeValue;
        public T BaseValue => baseValue;

        public T LastValue => lastValue;

        [TableColumnWidth(90, Resizable = false)]
        [ShowInInspector]
        [HorizontalGroup(ConventionKey.CurrentValue)]
        [HideLabel]
        public virtual T Value
        {
            get => currentValue;
            set
            {
                if (!CanChangeValueTo(value))
                {
                    return;
                }

                if (duplicateCheck && currentValue.Equals(value)) return;
                lastValue = currentValue;
                currentValue = value;
                EmitEventDeepChanged();
                EmitEventChanged();
            }
        }

        public APrimitiveData()
        {
            baseValue = default;
            lastValue = baseValue;
            currentValue = baseValue;
        }

        public APrimitiveData(T baseValue)
        {
            this.baseValue = baseValue;
            lastValue = this.baseValue;
            currentValue = this.baseValue;
        }

        public APrimitiveData(T baseValue, T lastValue, T currentValue)
        {
            this.baseValue = baseValue;
            this.lastValue = lastValue;
            this.currentValue = currentValue;
        }

        public event Action<T> OnChanged;
        public event Action<T, T, T> OnDeepChanged;


        [TableColumnWidth(60)]
        [FoldoutGroup(ConventionKey.Settings)]
        [Button]
        public void SetBaseValue(T value, bool emmitEvent = true)
        {
            baseValue = value;
            lastValue = baseValue;
            currentValue = baseValue;
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
        
        public void SetDuplicateCheck(bool value)
        {
            duplicateCheck = value;
        }

        protected virtual bool CanChangeValueTo(T value)
        {
            if (CanChangeValue == default) return true;
            var canChange = CanChangeValue.Invoke(value);
            return canChange;
        }

        protected virtual void EmitEventChanged()
        {
            OnChanged?.Invoke(currentValue);
        }

        protected virtual void EmitEventDeepChanged()
        {
            OnDeepChanged?.Invoke(baseValue, lastValue, currentValue);
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
    public class Vector2Data : APrimitiveData<Vector2>
    {
        public Vector2Data(Vector2 baseValue) : base(baseValue)
        {
        }
    }

    [Serializable]
    public class Vector3Data : APrimitiveData<Vector3>
    {
        public Vector3Data(Vector3 baseValue) : base(baseValue)
        {
        }
    }

    [Serializable]
    public class Vector4Data : APrimitiveData<Vector4>
    {
        public Vector4Data(Vector4 baseValue) : base(baseValue)
        {
        }
    }

    [Serializable]
    public class QuaternionData : APrimitiveData<Quaternion>
    {
        public QuaternionData(Quaternion baseValue) : base(baseValue)
        {
        }
    }

    [Serializable]
    public class ColorData : APrimitiveData<Color>
    {
        public ColorData(Color baseValue) : base(baseValue)
        {
        }
    }

    [Serializable]
    public class BoundsData : APrimitiveData<Bounds>
    {
        public BoundsData(Bounds baseValue) : base(baseValue)
        {
        }
    }

    [Serializable]
    public class RectData : APrimitiveData<Rect>
    {
        public RectData(Rect baseValue) : base(baseValue)
        {
        }
    }

    #endregion
}