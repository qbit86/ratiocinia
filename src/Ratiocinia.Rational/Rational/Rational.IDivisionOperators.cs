namespace Ratiocinia
{
    using Algorithms.Specialized;

    partial struct Rational<T>
    {
        /// <summary>
        /// Divides one rational number by another.
        /// </summary>
        /// <param name="left">The dividend.</param>
        /// <param name="right">The divisor.</param>
        /// <returns>The quotient of <paramref name="left" /> divided by <paramref name="right" />.</returns>
        /// <exception cref="System.DivideByZeroException">
        /// Thrown when <paramref name="right" /> is zero.
        /// </exception>
        public static Rational<T> operator /(Rational<T> left, Rational<T> right) =>
            Divide(left, right);

        /// <summary>
        /// Divides one rational number by another with overflow checking.
        /// </summary>
        /// <param name="left">The dividend.</param>
        /// <param name="right">The divisor.</param>
        /// <returns>The quotient of <paramref name="left" /> divided by <paramref name="right" />.</returns>
        /// <exception cref="System.DivideByZeroException">
        /// Thrown when <paramref name="right" /> is zero.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// Thrown when the operation causes an arithmetic overflow.
        /// </exception>
        public static Rational<T> operator checked /(Rational<T> left, Rational<T> right)
        {
            var (numerator, denominator) = CheckedRationalOperations.Divide(
                left.Numerator, left.Denominator, right.Numerator, right.Denominator);
            return UnsafeCreate(numerator, denominator);
        }

        /// <summary>
        /// Divides one rational number by another.
        /// </summary>
        /// <param name="left">The dividend.</param>
        /// <param name="right">The divisor.</param>
        /// <returns>The quotient of <paramref name="left" /> divided by <paramref name="right" />.</returns>
        /// <exception cref="System.DivideByZeroException">
        /// Thrown when <paramref name="right" /> is zero.
        /// </exception>
        public static Rational<T> Divide(Rational<T> left, Rational<T> right)
        {
            var (numerator, denominator) = UncheckedRationalOperations.Divide(
                left.Numerator, left.Denominator, right.Numerator, right.Denominator);
            return UnsafeCreate(numerator, denominator);
        }
    }
}
