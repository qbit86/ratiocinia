namespace Ratiocinia
{
    using Algorithms.Specialized;

    partial struct Rational<T>
    {
        /// <summary>
        /// Adds two rational numbers.
        /// </summary>
        /// <param name="left">The first rational number to add.</param>
        /// <param name="right">The second rational number to add.</param>
        /// <returns>The sum of <paramref name="left" /> and <paramref name="right" />.</returns>
        public static Rational<T> operator +(Rational<T> left, Rational<T> right) =>
            Add(left, right);

        /// <summary>
        /// Adds two rational numbers with overflow checking.
        /// </summary>
        /// <param name="left">The first rational number to add.</param>
        /// <param name="right">The second rational number to add.</param>
        /// <returns>The sum of <paramref name="left" /> and <paramref name="right" />.</returns>
        /// <exception cref="System.OverflowException">
        /// Thrown when the operation causes an arithmetic overflow.
        /// </exception>
        public static Rational<T> operator checked +(Rational<T> left, Rational<T> right)
        {
            var (numerator, denominator) = CheckedRationalOperations.Add(
                left.Numerator, left.Denominator, right.Numerator, right.Denominator);
            return UnsafeCreate(numerator, denominator);
        }

        /// <summary>
        /// Adds two rational numbers.
        /// </summary>
        /// <param name="left">The first rational number to add.</param>
        /// <param name="right">The second rational number to add.</param>
        /// <returns>The sum of <paramref name="left" /> and <paramref name="right" />.</returns>
        public static Rational<T> Add(Rational<T> left, Rational<T> right)
        {
            var (numerator, denominator) = UncheckedRationalOperations.Add(
                left.Numerator, left.Denominator, right.Numerator, right.Denominator);
            return UnsafeCreate(numerator, denominator);
        }
    }
}
