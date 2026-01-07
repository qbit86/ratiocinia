namespace Ratiocinia
{
    using System;
    using System.Diagnostics;
    using System.Numerics;
    using Algorithms.Specialized;

    partial struct BigIntegerRational :
        IComparable<BigIntegerRational>, IComparisonOperators<BigIntegerRational, BigIntegerRational, bool>
    {
        public int CompareTo(BigIntegerRational other)
        {
            if (Equals(other))
                return 0;

            if (BigIntegerRationalOperations.LessThan(Numerator, Denominator, other.Numerator, other.Denominator))
                return -1;

            Debug.Assert(
                BigIntegerRationalOperations.LessThan(other.Numerator, other.Denominator, Numerator, Denominator));
            return 1;
        }

        public static bool operator >(BigIntegerRational left, BigIntegerRational right) =>
            BigIntegerRationalOperations.LessThan(right.Numerator, right.Denominator, left.Numerator, left.Denominator);

        public static bool operator >=(BigIntegerRational left, BigIntegerRational right) =>
            !BigIntegerRationalOperations.LessThan(
                left.Numerator, left.Denominator, right.Numerator, right.Denominator);

        public static bool operator <(BigIntegerRational left, BigIntegerRational right) =>
            BigIntegerRationalOperations.LessThan(left.Numerator, left.Denominator, right.Numerator, right.Denominator);

        public static bool operator <=(BigIntegerRational left, BigIntegerRational right) =>
            !BigIntegerRationalOperations.LessThan(
                right.Numerator, right.Denominator, left.Numerator, left.Denominator);
    }
}
