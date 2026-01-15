namespace Ratiocinia
{
    using Algorithms.Specialized;

    partial struct BigIntegerRational
    {
        /// <summary>
        /// Multiplies two rational numbers.
        /// </summary>
        /// <param name="left">The first rational number to multiply.</param>
        /// <param name="right">The second rational number to multiply.</param>
        /// <returns>The product of <paramref name="left" /> and <paramref name="right" />.</returns>
        public static BigIntegerRational operator *(BigIntegerRational left, BigIntegerRational right) =>
            Multiply(left, right);

        /// <summary>
        /// Multiplies two rational numbers.
        /// </summary>
        /// <param name="left">The first rational number to multiply.</param>
        /// <param name="right">The second rational number to multiply.</param>
        /// <returns>The product of <paramref name="left" /> and <paramref name="right" />.</returns>
        /// <remarks>
        /// Since <see cref="BigIntegerRational" /> uses arbitrary precision arithmetic,
        /// this operator behaves identically to the unchecked version.
        /// </remarks>
        public static BigIntegerRational operator checked *(BigIntegerRational left, BigIntegerRational right) =>
            Multiply(left, right);

        /// <summary>
        /// Multiplies two rational numbers.
        /// </summary>
        /// <param name="left">The first rational number to multiply.</param>
        /// <param name="right">The second rational number to multiply.</param>
        /// <returns>The product of <paramref name="left" /> and <paramref name="right" />.</returns>
        public static BigIntegerRational Multiply(BigIntegerRational left, BigIntegerRational right)
        {
            var (numerator, denominator) = BigIntegerRationalOperations.Multiply(
                left.Numerator, left.Denominator, right.Numerator, right.Denominator);
            return UnsafeCreate(numerator, denominator);
        }
    }
}
