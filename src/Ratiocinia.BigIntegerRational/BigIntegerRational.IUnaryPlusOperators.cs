namespace Ratiocinia
{
    partial struct BigIntegerRational
    {
        /// <summary>
        /// Returns the unary plus of a rational number (the value unchanged).
        /// </summary>
        /// <param name="value">The rational number.</param>
        /// <returns>The value of <paramref name="value" /> unchanged.</returns>
        public static BigIntegerRational operator +(BigIntegerRational value) => value;

        /// <summary>
        /// Returns the unary plus of a rational number (the value unchanged).
        /// </summary>
        /// <param name="value">The rational number.</param>
        /// <returns>The value of <paramref name="value" /> unchanged.</returns>
        public static BigIntegerRational Plus(BigIntegerRational value) => value;
    }
}
