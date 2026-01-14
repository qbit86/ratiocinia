namespace Ratiocinia
{
    using Algorithms.Specialized;

    partial struct BigIntegerRational
    {
        /// <summary>
        /// Subtracts one rational number from another.
        /// </summary>
        /// <param name="left">The minuend.</param>
        /// <param name="right">The subtrahend.</param>
        /// <returns>The difference of <paramref name="left" /> and <paramref name="right" />.</returns>
        public static BigIntegerRational operator -(BigIntegerRational left, BigIntegerRational right) =>
            Subtract(left, right);

        /// <summary>
        /// Subtracts one rational number from another.
        /// </summary>
        /// <param name="left">The minuend.</param>
        /// <param name="right">The subtrahend.</param>
        /// <returns>The difference of <paramref name="left" /> and <paramref name="right" />.</returns>
        /// <remarks>
        /// Since <see cref="BigIntegerRational" /> uses arbitrary precision arithmetic,
        /// this operator behaves identically to the unchecked version.
        /// </remarks>
        public static BigIntegerRational operator checked -(BigIntegerRational left, BigIntegerRational right) =>
            Subtract(left, right);

        /// <summary>
        /// Subtracts one rational number from another.
        /// </summary>
        /// <param name="left">The minuend.</param>
        /// <param name="right">The subtrahend.</param>
        /// <returns>The difference of <paramref name="left" /> and <paramref name="right" />.</returns>
        public static BigIntegerRational Subtract(BigIntegerRational left, BigIntegerRational right)
        {
            var (numerator, denominator) = BigIntegerRationalOperations.Subtract(
                left.Numerator, left.Denominator, right.Numerator, right.Denominator);
            return UnsafeCreate(numerator, denominator);
        }
    }
}
