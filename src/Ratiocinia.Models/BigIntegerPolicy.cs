namespace Ratiocinia.Models
{
    using System.Numerics;

    public sealed class BigIntegerPolicy :
        IGreatestCommonDivisorFunctions<BigInteger>,
        IUnaryNegationFunctions<BigInteger>,
        IUncheckedAdditionFunctions<BigInteger>,
        IUncheckedDivisionFunctions<BigInteger>,
        IUncheckedSubtractionFunctions<BigInteger>,
        IUncheckedMultiplyFunctions<BigInteger>
    {
        public static BigIntegerPolicy Instance { get; } = new();

        BigInteger IGreatestCommonDivisorFunctions<BigInteger>.Gcd(BigInteger left, BigInteger right) =>
            BigInteger.GreatestCommonDivisor(left, right);

        BigInteger IUnaryNegationFunctions<BigInteger>.Negate(BigInteger value) => -value;
    }
}
