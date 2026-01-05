namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    public sealed class BigIntegerPolicy :
        IComparable<BigInteger>,
        IGreatestCommonDivisorFunctions<BigInteger>,
        IUnaryNegationFunctions<BigInteger>,
        IUncheckedAdditionFunctions<BigInteger>,
        IUncheckedDivisionFunctions<BigInteger>,
        IUncheckedSubtractionFunctions<BigInteger>,
        IUncheckedMultiplyFunctions<BigInteger>
    {
        public static BigIntegerPolicy Instance { get; } = new();

        int IComparable<BigInteger>.CompareTo(BigInteger other) => BigInteger.Zero.CompareTo(other);

        BigInteger IGreatestCommonDivisorFunctions<BigInteger>.Gcd(BigInteger left, BigInteger right) =>
            BigInteger.GreatestCommonDivisor(left, right);

        BigInteger IUnaryNegationFunctions<BigInteger>.Negate(BigInteger value) => -value;
    }
}
