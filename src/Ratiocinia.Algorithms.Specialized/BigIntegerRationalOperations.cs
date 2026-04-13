namespace Ratiocinia.Algorithms.Specialized
{
    using System.Numerics;
    using Generic;
    using Models;

    /// <summary>
    /// Provides arithmetic operations for rational numbers represented as <see cref="BigInteger" /> pairs.
    /// </summary>
    public static class BigIntegerRationalOperations
    {
        /// <summary>
        /// Adds two rational numbers.
        /// </summary>
        /// <param name="leftNumerator">The numerator of the first rational number.</param>
        /// <param name="leftDenominator">The denominator of the first rational number.</param>
        /// <param name="rightNumerator">The numerator of the second rational number.</param>
        /// <param name="rightDenominator">The denominator of the second rational number.</param>
        /// <returns>A tuple containing the numerator and denominator of the sum in normalized form.</returns>
        public static (BigInteger Numerator, BigInteger Denominator) Add(
            BigInteger leftNumerator, BigInteger leftDenominator, BigInteger rightNumerator,
            BigInteger rightDenominator) =>
            global::Ratiocinia.Algorithms.Generic.Internal.RationalOperations.Add(
                leftNumerator, leftDenominator, rightNumerator, rightDenominator, BigIntegerPolicy.Instance);

        /// <summary>
        /// Divides one rational number by another.
        /// </summary>
        /// <param name="leftNumerator">The numerator of the dividend.</param>
        /// <param name="leftDenominator">The denominator of the dividend.</param>
        /// <param name="rightNumerator">The numerator of the divisor.</param>
        /// <param name="rightDenominator">The denominator of the divisor.</param>
        /// <returns>A tuple containing the numerator and denominator of the quotient in normalized form.</returns>
        public static (BigInteger Numerator, BigInteger Denominator) Divide(
            BigInteger leftNumerator, BigInteger leftDenominator, BigInteger rightNumerator,
            BigInteger rightDenominator) =>
            global::Ratiocinia.Algorithms.Generic.Internal.RationalOperations.Divide(
                leftNumerator, leftDenominator, rightNumerator, rightDenominator,
                BigInteger.Zero, BigIntegerPolicy.Instance);

        /// <summary>
        /// Multiplies two rational numbers.
        /// </summary>
        /// <param name="leftNumerator">The numerator of the first rational number.</param>
        /// <param name="leftDenominator">The denominator of the first rational number.</param>
        /// <param name="rightNumerator">The numerator of the second rational number.</param>
        /// <param name="rightDenominator">The denominator of the second rational number.</param>
        /// <returns>A tuple containing the numerator and denominator of the product in normalized form.</returns>
        public static (BigInteger Numerator, BigInteger Denominator) Multiply(
            BigInteger leftNumerator, BigInteger leftDenominator, BigInteger rightNumerator,
            BigInteger rightDenominator) =>
            global::Ratiocinia.Algorithms.Generic.Internal.RationalOperations.Multiply(
                leftNumerator, leftDenominator, rightNumerator, rightDenominator, BigIntegerPolicy.Instance);

        /// <summary>
        /// Subtracts one rational number from another.
        /// </summary>
        /// <param name="leftNumerator">The numerator of the minuend.</param>
        /// <param name="leftDenominator">The denominator of the minuend.</param>
        /// <param name="rightNumerator">The numerator of the subtrahend.</param>
        /// <param name="rightDenominator">The denominator of the subtrahend.</param>
        /// <returns>A tuple containing the numerator and denominator of the difference in normalized form.</returns>
        public static (BigInteger Numerator, BigInteger Denominator) Subtract(
            BigInteger leftNumerator, BigInteger leftDenominator, BigInteger rightNumerator,
            BigInteger rightDenominator) =>
            global::Ratiocinia.Algorithms.Generic.Internal.RationalOperations.Subtract(
                leftNumerator, leftDenominator, rightNumerator, rightDenominator, BigIntegerPolicy.Instance);

        /// <summary>
        /// Negates a rational number.
        /// </summary>
        /// <param name="numerator">The numerator of the rational number.</param>
        /// <param name="denominator">The denominator of the rational number.</param>
        /// <returns>A tuple containing the numerator and denominator of the negated rational number.</returns>
        public static (BigInteger Numerator, BigInteger Denominator) Negate(
            BigInteger numerator, BigInteger denominator) =>
            global::Ratiocinia.Algorithms.Generic.Internal.RationalOperations.Negate(
                numerator, denominator, BigIntegerPolicy.Instance);

        /// <summary>
        /// Normalizes a rational number by reducing it to lowest terms and ensuring the denominator is positive.
        /// </summary>
        /// <param name="numerator">The numerator of the rational number.</param>
        /// <param name="denominator">The denominator of the rational number.</param>
        /// <returns>A tuple containing the numerator and denominator in normalized form.</returns>
        public static (BigInteger Numerator, BigInteger Denominator) Normalize(
            BigInteger numerator, BigInteger denominator) =>
            global::Ratiocinia.Algorithms.Generic.Internal.RationalOperations.Normalize(
                numerator,
                denominator,
                BigInteger.Zero,
                BigInteger.One,
                BigInteger.Zero,
                BigIntegerPolicy.Instance);

        /// <summary>
        /// Determines whether a rational number is in normalized form.
        /// </summary>
        /// <param name="numerator">The numerator of the rational number.</param>
        /// <param name="denominator">The denominator of the rational number.</param>
        /// <returns><see langword="true" /> if the rational number is normalized; otherwise, <see langword="false" />.</returns>
        public static bool IsNormalized(BigInteger numerator, BigInteger denominator) =>
            global::Ratiocinia.Algorithms.Generic.Internal.RationalOperations.IsNormalized(
                numerator, denominator, BigInteger.Zero, BigInteger.One, BigIntegerPolicy.Instance);

        /// <summary>
        /// Determines whether one rational number is less than another.
        /// </summary>
        /// <param name="leftNumerator">The numerator of the first rational number.</param>
        /// <param name="leftDenominator">The denominator of the first rational number.</param>
        /// <param name="rightNumerator">The numerator of the second rational number.</param>
        /// <param name="rightDenominator">The denominator of the second rational number.</param>
        /// <returns><see langword="true" /> if the first rational number is less than the second; otherwise, <see langword="false" />.</returns>
        public static bool LessThan(
            BigInteger leftNumerator, BigInteger leftDenominator, BigInteger rightNumerator,
            BigInteger rightDenominator) =>
            leftNumerator * rightDenominator < rightNumerator * leftDenominator;
    }
}
