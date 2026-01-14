namespace Ratiocinia
{
    using Algorithms.Specialized;

    partial struct BigIntegerRational
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
        public static BigIntegerRational operator /(BigIntegerRational left, BigIntegerRational right) =>
            Divide(left, right);

        /// <summary>
        /// Divides one rational number by another.
        /// </summary>
        /// <param name="left">The dividend.</param>
        /// <param name="right">The divisor.</param>
        /// <returns>The quotient of <paramref name="left" /> divided by <paramref name="right" />.</returns>
        /// <exception cref="System.DivideByZeroException">
        /// Thrown when <paramref name="right" /> is zero.
        /// </exception>
        /// <remarks>
        /// Since <see cref="BigIntegerRational" /> uses arbitrary precision arithmetic,
        /// this operator behaves identically to the unchecked version.
        /// </remarks>
        public static BigIntegerRational operator checked /(BigIntegerRational left, BigIntegerRational right) =>
            Divide(left, right);

        /// <summary>
        /// Divides one rational number by another.
        /// </summary>
        /// <param name="left">The dividend.</param>
        /// <param name="right">The divisor.</param>
        /// <returns>The quotient of <paramref name="left" /> divided by <paramref name="right" />.</returns>
        /// <exception cref="System.DivideByZeroException">
        /// Thrown when <paramref name="right" /> is zero.
        /// </exception>
        public static BigIntegerRational Divide(BigIntegerRational left, BigIntegerRational right)
        {
            var (numerator, denominator) = BigIntegerRationalOperations.Divide(
                left.Numerator, left.Denominator, right.Numerator, right.Denominator);
            return UnsafeCreate(numerator, denominator);
        }
    }
}
