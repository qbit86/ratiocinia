namespace Ratiocinia
{
    using System;
    using System.Diagnostics;
    using Algorithms.Specialized;

    partial struct Rational<T> : IComparable<Rational<T>>
    {
        public int CompareTo(Rational<T> other)
        {
            // NaN compares greater than any non-NaN
            if (Equals(other))
                return 0;

            if (UncheckedRationalOperations.LessThan(Numerator, Denominator, other.Numerator, other.Denominator))
                return -1;

            Debug.Assert(
                UncheckedRationalOperations.LessThan(other.Numerator, other.Denominator, Numerator, Denominator));
            return 1;
        }
    }
}
