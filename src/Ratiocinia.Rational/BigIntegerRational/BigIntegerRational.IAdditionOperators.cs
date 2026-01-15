namespace Ratiocinia
{
    using Algorithms.Specialized;

    partial struct BigIntegerRational
    {
        /// <summary>
        /// Adds two rational numbers.
        /// </summary>
        /// <param name="left">The first rational number to add.</param>
        /// <param name="right">The second rational number to add.</param>
        /// <returns>The sum of <paramref name="left" /> and <paramref name="right" />.</returns>
        public static BigIntegerRational operator +(BigIntegerRational left, BigIntegerRational right) =>
            Add(left, right);

        /// <summary>
        /// Adds two rational numbers.
        /// </summary>
        /// <param name="left">The first rational number to add.</param>
        /// <param name="right">The second rational number to add.</param>
        /// <returns>The sum of <paramref name="left" /> and <paramref name="right" />.</returns>
        /// <remarks>
        /// Since <see cref="BigIntegerRational" /> uses arbitrary precision arithmetic,
        /// this operator behaves identically to the unchecked version.
        /// </remarks>
        public static BigIntegerRational operator checked +(BigIntegerRational left, BigIntegerRational right) =>
            Add(left, right);

        /// <summary>
        /// Adds two rational numbers.
        /// </summary>
        /// <param name="left">The first rational number to add.</param>
        /// <param name="right">The second rational number to add.</param>
        /// <returns>The sum of <paramref name="left" /> and <paramref name="right" />.</returns>
        public static BigIntegerRational Add(BigIntegerRational left, BigIntegerRational right)
        {
            var (numerator, denominator) = BigIntegerRationalOperations.Add(
                left.Numerator, left.Denominator, right.Numerator, right.Denominator);
            return UnsafeCreate(numerator, denominator);
        }
    }
}
