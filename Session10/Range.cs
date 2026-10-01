using System;

namespace Session10
{
    // T must implement IComparable<T> to allow comparisons like value.CompareTo(Min)
    public class Range<T> where T : IComparable<T>
    {
        public T Min { get; set; }
        public T Max { get; set; }

        public Range(T min, T max)
        {
            Min = min;
            Max = max;
        }

        public bool IsInRange(T value)
        {
            return value.CompareTo(Min) >= 0 && value.CompareTo(Max) <= 0;
        }

        // Generic T can't be subtracted directly (not all types support "-"),
        // so we convert to double to calculate the numeric length.
        public double Length()
        {
            return Convert.ToDouble(Max) - Convert.ToDouble(Min);
        }
    }
}