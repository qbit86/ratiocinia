namespace Ratiocinia
{
    using System;
    using System.Diagnostics;
    using System.Numerics;
    using Algorithms.Specialized;

    partial struct Rational<T> : IComparable<Rational<T>>, IComparisonOperators<Rational<T>, Rational<T>, bool>
    {
        public int CompareTo(Rational<T> other)
        {
            if (Equals(other))
                return 0;

            if (CheckedRationalOperations.LessThan(Numerator, Denominator, other.Numerator, other.Denominator))
                return -1;

            Debug.Assert(
                CheckedRationalOperations.LessThan(other.Numerator, other.Denominator, Numerator, Denominator));
            return 1;
        }

        public static bool operator >(Rational<T> left, Rational<T> right) =>
            CheckedRationalOperations.LessThan(right.Numerator, right.Denominator, left.Numerator, left.Denominator);

        public static bool operator >=(Rational<T> left, Rational<T> right) =>
            !CheckedRationalOperations.LessThan(left.Numerator, left.Denominator, right.Numerator, right.Denominator);

        public static bool operator <(Rational<T> left, Rational<T> right) =>
            CheckedRationalOperations.LessThan(left.Numerator, left.Denominator, right.Numerator, right.Denominator);

        public static bool operator <=(Rational<T> left, Rational<T> right) =>
            !CheckedRationalOperations.LessThan(right.Numerator, right.Denominator, left.Numerator, left.Denominator);
    }
}
