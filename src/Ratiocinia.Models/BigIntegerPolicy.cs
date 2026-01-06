namespace Ratiocinia.Models
{
    using System.Collections.Generic;
    using System.Numerics;

    public sealed class BigIntegerPolicy :
        IComparer<BigInteger>,
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

        public int Compare(BigInteger x, BigInteger y) => x.CompareTo(y);

        public BigInteger Gcd(BigInteger left, BigInteger right) => BigInteger.GreatestCommonDivisor(left, right);
    }
}
