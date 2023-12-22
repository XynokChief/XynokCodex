using System;
using UnityEngine;
using XynokConvention.Enums;

namespace XynokUtils
{
    public partial class XynokUtility
    {
        public static class DataUtils
        {
            public static bool IsValid(float target, float other, OperatorComparison comparison)
            {
                switch (comparison)
                {
                    case OperatorComparison.Equal:
                        return Math.Abs(target - other) < Mathf.Epsilon;
                    case OperatorComparison.NotEqual:
                        return Math.Abs(target - other) > Mathf.Epsilon;
                    case OperatorComparison.GreaterThan:
                        return target > other;
                    case OperatorComparison.GreaterOrEqual:
                        return target >= other;
                    case OperatorComparison.LessThan:
                        return target < other;
                    case OperatorComparison.LessOrEqual:
                        return target <= other;
                    default:
                        return false;
                }
            }
        }
    }
}