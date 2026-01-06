namespace Ratiocinia.Models
{
    using System.Numerics;

    public sealed class BigIntegerPolicy :
        IGreatestCommonDivisorFunctions<BigInteger>,
        INumberBaseAbsoluteFunctions<BigInteger>,
        INumberModulusFunctions<BigInteger>,
        IUncheckedAdditionFunctions<BigInteger>,
        IUncheckedDivisionFunctions<BigInteger>,
        IUncheckedSubtractionFunctions<BigInteger>,
        IUncheckedMultiplyFunctions<BigInteger>,
        IUncheckedUnaryNegationFunctions<BigInteger>
    {
        public static BigIntegerPolicy Instance { get; } = new();

        public BigInteger Gcd(BigInteger left, BigInteger right) => BigInteger.GreatestCommonDivisor(left, right);
    }
}
