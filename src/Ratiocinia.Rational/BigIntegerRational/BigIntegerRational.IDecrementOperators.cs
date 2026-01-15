namespace Ratiocinia
{
    partial struct BigIntegerRational
    {
        /// <summary>
        /// Decrements a rational number by one.
        /// </summary>
        /// <param name="value">The rational number to decrement.</param>
        /// <returns>The value of <paramref name="value" /> decremented by one.</returns>
        public static BigIntegerRational operator --(BigIntegerRational value) => Decrement(value);

        /// <summary>
        /// Decrements a rational number by one.
        /// </summary>
        /// <param name="value">The rational number to decrement.</param>
        /// <returns>The value of <paramref name="value" /> decremented by one.</returns>
        /// <remarks>
        /// Since <see cref="BigIntegerRational" /> uses arbitrary precision arithmetic,
        /// this operator behaves identically to the unchecked version.
        /// </remarks>
        public static BigIntegerRational operator checked --(BigIntegerRational value) => Decrement(value);

        /// <summary>
        /// Decrements a rational number by one.
        /// </summary>
        /// <param name="value">The rational number to decrement.</param>
        /// <returns>The value of <paramref name="value" /> decremented by one.</returns>
        public static BigIntegerRational Decrement(BigIntegerRational value) =>
            UnsafeCreate(value.Numerator - value.Denominator, value.Denominator);
    }
}
