namespace Ratiocinia.Models
{
    using System.Numerics;

    public sealed class BigIntegerPolicy :
        IPartialNumberUncheckedPolicy<BigInteger>,
        IGreatestCommonDivisorFunctions<BigInteger>
    {
        public static BigIntegerPolicy Instance { get; } = new();

        BigInteger IGreatestCommonDivisorFunctions<BigInteger>.Gcd(BigInteger left, BigInteger right) =>
            BigInteger.GreatestCommonDivisor(left, right);
    }
}
