namespace Ratiocinia.Models
{
    using System.Numerics;

    public interface IBigIntegerPolicy :
        IPartialNumberPolicy<BigInteger>,
        IGreatestCommonDivisorFunctions<BigInteger>
    {
        BigInteger IGreatestCommonDivisorFunctions<BigInteger>.Gcd(BigInteger left, BigInteger right) =>
            BigInteger.GreatestCommonDivisor(left, right);
    }

    public sealed class BigIntegerPolicy : IBigIntegerPolicy
    {
        public static BigIntegerPolicy Instance { get; } = new();
    }
}
