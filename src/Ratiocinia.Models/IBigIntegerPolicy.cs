namespace Ratiocinia.Models
{
    using System.Numerics;

    public interface IBigIntegerPolicy :
        IAdditionFunctions<BigInteger>,
        IDivisionFunctions<BigInteger>,
        IGreatestCommonDivisorFunctions<BigInteger>,
        IMultiplyFunctions<BigInteger>
    {
        BigInteger IAdditionFunctions<BigInteger>.Add(BigInteger left, BigInteger right) => left + right;

        BigInteger IDivisionFunctions<BigInteger>.Divide(BigInteger left, BigInteger right) => left / right;

        BigInteger IGreatestCommonDivisorFunctions<BigInteger>.Gcd(BigInteger left, BigInteger right) =>
            BigInteger.GreatestCommonDivisor(left, right);

        BigInteger IMultiplyFunctions<BigInteger>.Multiply(BigInteger left, BigInteger right) => left * right;
    }

    public sealed class BigIntegerPolicy : IBigIntegerPolicy
    {
        public static BigIntegerPolicy Instance { get; } = new();
    }
}
