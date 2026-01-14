namespace Ratiocinia
{
    partial struct BigIntegerRational
    {
        /// <summary>
        /// Increments a rational number by one.
        /// </summary>
        /// <param name="value">The rational number to increment.</param>
        /// <returns>The value of <paramref name="value" /> incremented by one.</returns>
        public static BigIntegerRational operator ++(BigIntegerRational value) => Increment(value);

        /// <summary>
        /// Increments a rational number by one.
        /// </summary>
        /// <param name="value">The rational number to increment.</param>
        /// <returns>The value of <paramref name="value" /> incremented by one.</returns>
        /// <remarks>
        /// Since <see cref="BigIntegerRational" /> uses arbitrary precision arithmetic,
        /// this operator behaves identically to the unchecked version.
        /// </remarks>
        public static BigIntegerRational operator checked ++(BigIntegerRational value) => Increment(value);

        /// <summary>
        /// Increments a rational number by one.
        /// </summary>
        /// <param name="value">The rational number to increment.</param>
        /// <returns>The value of <paramref name="value" /> incremented by one.</returns>
        public static BigIntegerRational Increment(BigIntegerRational value) =>
            UnsafeCreate(value.Numerator + value.Denominator, value.Denominator);
    }
}
