namespace Ratiocinia.Models
{
    using System.Numerics;

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
        public static BigIntegerPolicy Instance { get; } = new();

        public BigInteger Gcd(BigInteger left, BigInteger right) => BigInteger.GreatestCommonDivisor(left, right);
    }
}
