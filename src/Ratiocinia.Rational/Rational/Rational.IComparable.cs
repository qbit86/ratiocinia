namespace Ratiocinia
{
    using System;
    using System.Diagnostics;
    using System.Numerics;
    using Algorithms.Specialized;

    partial struct Rational<T> : IComparable<Rational<T>>, IComparisonOperators<Rational<T>, Rational<T>, bool>
    {
        /// <summary>
        /// Compares this rational number to another and returns an indication of their relative values.
        /// </summary>
        /// <param name="other">The rational number to compare to.</param>
        /// <returns>
        /// A negative value if this instance is less than <paramref name="other" />;
        /// zero if this instance equals <paramref name="other" />;
        /// a positive value if this instance is greater than <paramref name="other" />.
        /// </returns>
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

        /// <summary>
        /// Determines whether the first rational number is greater than the second.
        /// </summary>
        /// <param name="left">The first rational number to compare.</param>
        /// <param name="right">The second rational number to compare.</param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="left" /> is greater than <paramref name="right" />;
        /// otherwise, <see langword="false" />.
        /// </returns>
        public static bool operator >(Rational<T> left, Rational<T> right) =>
            CheckedRationalOperations.LessThan(right.Numerator, right.Denominator, left.Numerator, left.Denominator);

        /// <summary>
        /// Determines whether the first rational number is greater than or equal to the second.
        /// </summary>
        /// <param name="left">The first rational number to compare.</param>
        /// <param name="right">The second rational number to compare.</param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="left" /> is greater than or equal to <paramref name="right" />;
        /// otherwise, <see langword="false" />.
        /// </returns>
        public static bool operator >=(Rational<T> left, Rational<T> right) =>
            !CheckedRationalOperations.LessThan(left.Numerator, left.Denominator, right.Numerator, right.Denominator);

        /// <summary>
        /// Determines whether the first rational number is less than the second.
        /// </summary>
        /// <param name="left">The first rational number to compare.</param>
        /// <param name="right">The second rational number to compare.</param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="left" /> is less than <paramref name="right" />;
        /// otherwise, <see langword="false" />.
        /// </returns>
        public static bool operator <(Rational<T> left, Rational<T> right) =>
            CheckedRationalOperations.LessThan(left.Numerator, left.Denominator, right.Numerator, right.Denominator);

        /// <summary>
        /// Determines whether the first rational number is less than or equal to the second.
        /// </summary>
        /// <param name="left">The first rational number to compare.</param>
        /// <param name="right">The second rational number to compare.</param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="left" /> is less than or equal to <paramref name="right" />;
        /// otherwise, <see langword="false" />.
        /// </returns>
        public static bool operator <=(Rational<T> left, Rational<T> right) =>
            !CheckedRationalOperations.LessThan(right.Numerator, right.Denominator, left.Numerator, left.Denominator);
    }
}
