namespace Ratiocinia.Algorithms.Generic
{
    public static class RationalOperations
    {
        public static (T Numerator, T Denominator) Multiply<T, TPolicy>(
            T leftNumerator, T leftDenominator, T rightNumerator, T rightDenominator, TPolicy policy)
            where TPolicy : IDivisionFunctions<T>, IGreatestCommonDivisorFunctions<T>, IMultiplyFunctions<T>
        {
            // https://github.com/boostorg/rational/blob/boost-1.90.0/include/boost/rational.hpp#L571
            var gcd1 = policy.Gcd(leftNumerator, rightDenominator);
            var gcd2 = policy.Gcd(leftDenominator, rightNumerator);
            var numerator = policy.Multiply(policy.Divide(leftNumerator, gcd1), policy.Divide(rightNumerator, gcd2));
            var denominator =
                policy.Multiply(policy.Divide(leftDenominator, gcd2), policy.Divide(rightDenominator, gcd1));

            return (numerator, denominator);
        }
    }
}
