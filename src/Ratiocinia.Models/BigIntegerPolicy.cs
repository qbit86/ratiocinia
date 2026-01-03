namespace Ratiocinia.Models
{
    using System.Collections.Generic;
    using System.Numerics;

    public sealed class BigIntegerPolicy :
        IPartialNumberUncheckedPolicy<BigInteger>,
        IGreatestCommonDivisorFunctions<BigInteger>,
        IAdditiveIdentity<BigInteger>,
        IComparer<BigInteger>,
        IUnaryNegationFunctions<BigInteger>
    {
        public static BigIntegerPolicy Instance { get; } = new();

        BigInteger IAdditiveIdentity<BigInteger>.AdditiveIdentity => BigInteger.Zero;

        int IComparer<BigInteger>.Compare(BigInteger x, BigInteger y) => BigInteger.Compare(x, y);

        BigInteger IGreatestCommonDivisorFunctions<BigInteger>.Gcd(BigInteger left, BigInteger right) =>
            BigInteger.GreatestCommonDivisor(left, right);

        BigInteger IUnaryNegationFunctions<BigInteger>.Negate(BigInteger value) => -value;
    }
}
