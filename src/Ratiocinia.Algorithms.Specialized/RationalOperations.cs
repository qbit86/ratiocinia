namespace Ratiocinia.Algorithms.Specialized
{
    using System.Numerics;
    using Models;

    public static class RationalOperations
    {
        public static (BigInteger Numerator, BigInteger Denominator) Add(
            BigInteger leftNumerator, BigInteger leftDenominator, BigInteger rightNumerator,
            BigInteger rightDenominator) =>
            Generic.RationalOperations.Add(
                leftNumerator, leftDenominator, rightNumerator, rightDenominator, BigIntegerPolicy.Instance);
    }
}
