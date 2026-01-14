namespace Ratiocinia
{
    using Algorithms.Specialized;

    partial struct Rational<T>
    {
        /// <summary>
        /// Multiplies two rational numbers.
        /// </summary>
        /// <param name="left">The first rational number to multiply.</param>
        /// <param name="right">The second rational number to multiply.</param>
        /// <returns>The product of <paramref name="left" /> and <paramref name="right" />.</returns>
        public static Rational<T> operator *(Rational<T> left, Rational<T> right) =>
            Multiply(left, right);

        /// <summary>
        /// Multiplies two rational numbers with overflow checking.
        /// </summary>
        /// <param name="left">The first rational number to multiply.</param>
        /// <param name="right">The second rational number to multiply.</param>
        /// <returns>The product of <paramref name="left" /> and <paramref name="right" />.</returns>
        /// <exception cref="System.OverflowException">
        /// Thrown when the operation causes an arithmetic overflow.
        /// </exception>
        public static Rational<T> operator checked *(Rational<T> left, Rational<T> right)
        {
            var (numerator, denominator) = CheckedRationalOperations.Multiply(
                left.Numerator, left.Denominator, right.Numerator, right.Denominator);
            return UnsafeCreate(numerator, denominator);
        }

        /// <summary>
        /// Multiplies two rational numbers.
        /// </summary>
        /// <param name="left">The first rational number to multiply.</param>
        /// <param name="right">The second rational number to multiply.</param>
        /// <returns>The product of <paramref name="left" /> and <paramref name="right" />.</returns>
        public static Rational<T> Multiply(Rational<T> left, Rational<T> right)
        {
            var (numerator, denominator) = UncheckedRationalOperations.Multiply(
                left.Numerator, left.Denominator, right.Numerator, right.Denominator);
            return UnsafeCreate(numerator, denominator);
        }
    }
}
