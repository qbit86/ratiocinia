namespace Ratiocinia
{
    using Algorithms.Specialized;

    partial struct Rational<T>
    {
        /// <summary>
        /// Negates a rational number.
        /// </summary>
        /// <param name="value">The rational number to negate.</param>
        /// <returns>The negation of <paramref name="value" />.</returns>
        public static Rational<T> operator -(Rational<T> value) => Negate(value);

        /// <summary>
        /// Negates a rational number with overflow checking.
        /// </summary>
        /// <param name="value">The rational number to negate.</param>
        /// <returns>The negation of <paramref name="value" />.</returns>
        /// <exception cref="System.OverflowException">
        /// Thrown when the operation causes an arithmetic overflow.
        /// </exception>
        public static Rational<T> operator checked -(Rational<T> value)
        {
            var (numerator, denominator) = CheckedRationalOperations.Negate(value.Numerator, value.Denominator);
            return UnsafeCreate(numerator, denominator);
        }

        /// <summary>
        /// Negates a rational number.
        /// </summary>
        /// <param name="value">The rational number to negate.</param>
        /// <returns>The negation of <paramref name="value" />.</returns>
        public static Rational<T> Negate(Rational<T> value)
        {
            var (numerator, denominator) = UncheckedRationalOperations.Negate(value.Numerator, value.Denominator);
            return UnsafeCreate(numerator, denominator);
        }
    }
}
