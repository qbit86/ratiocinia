namespace Ratiocinia
{
    using Algorithms.Specialized;

    partial struct BigIntegerRational
    {
        /// <summary>
        /// Negates a rational number.
        /// </summary>
        /// <param name="value">The rational number to negate.</param>
        /// <returns>The negation of <paramref name="value" />.</returns>
        public static BigIntegerRational operator -(BigIntegerRational value) => Negate(value);

        /// <summary>
        /// Negates a rational number.
        /// </summary>
        /// <param name="value">The rational number to negate.</param>
        /// <returns>The negation of <paramref name="value" />.</returns>
        /// <remarks>
        /// Since <see cref="BigIntegerRational" /> uses arbitrary precision arithmetic,
        /// this operator behaves identically to the unchecked version.
        /// </remarks>
        public static BigIntegerRational operator checked -(BigIntegerRational value) => Negate(value);

        /// <summary>
        /// Negates a rational number.
        /// </summary>
        /// <param name="value">The rational number to negate.</param>
        /// <returns>The negation of <paramref name="value" />.</returns>
        public static BigIntegerRational Negate(BigIntegerRational value)
        {
            var (numerator, denominator) = BigIntegerRationalOperations.Negate(value.Numerator, value.Denominator);
            return UnsafeCreate(numerator, denominator);
        }
    }
}
