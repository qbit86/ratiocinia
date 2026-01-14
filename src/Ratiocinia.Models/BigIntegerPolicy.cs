namespace Ratiocinia.Models
{
    using System.Numerics;

    /// <summary>
    /// Provides arithmetic policy implementations for <see cref="BigInteger" /> values,
    /// including unchecked arithmetic operations, GCD computation, and comparison.
    /// </summary>
    public sealed class BigIntegerPolicy :
        IBinaryDivRemFunctions<BigInteger>,
        IComparableComparer<BigInteger>,
        IGreatestCommonDivisorFunctions<BigInteger>,
        INumberBaseAbsoluteFunctions<BigInteger>,
        INumericModulusFunctions<BigInteger>,
        IUncheckedAdditionFunctions<BigInteger>,
        IUncheckedDecrementFunctions<BigInteger>,
        IUncheckedDivisionFunctions<BigInteger>,
        IUncheckedSubtractionFunctions<BigInteger>,
        IUncheckedMultiplyFunctions<BigInteger>,
        IUncheckedUnaryNegationFunctions<BigInteger>
    {
        /// <summary>
        /// Gets the singleton instance of the <see cref="BigIntegerPolicy" /> class.
        /// </summary>
        public static BigIntegerPolicy Instance { get; } = new();

        /// <summary>
        /// Computes the greatest common divisor of two <see cref="BigInteger" /> values.
        /// </summary>
        /// <param name="left">The first value.</param>
        /// <param name="right">The second value.</param>
        /// <returns>The greatest common divisor of <paramref name="left" /> and <paramref name="right" />.</returns>
        public BigInteger Gcd(BigInteger left, BigInteger right) => BigInteger.GreatestCommonDivisor(left, right);
    }
}
