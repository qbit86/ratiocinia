namespace Ratiocinia.Algorithms.Generic
{
    using System;
    using System.Collections.Generic;

    public static class RationalOperations
    {
        public static (T Numerator, T Denominator) Add<T, TPolicy>(
            T leftNumerator, T leftDenominator, T rightNumerator, T rightDenominator, TPolicy policy)
            where TPolicy :
            IAdditionFunctions<T>,
            IDivisionFunctions<T>,
            IGreatestCommonDivisorFunctions<T>,
            IMultiplyFunctions<T>
        {
            // https://github.com/boostorg/rational/blob/boost-1.90.0/include/boost/rational.hpp#L517
            var gcd = policy.Gcd(leftDenominator, rightDenominator);
            leftDenominator = policy.Divide(leftDenominator, gcd);
            leftNumerator = policy.Add(
                policy.Multiply(leftNumerator, policy.Divide(rightDenominator, gcd)),
                policy.Multiply(rightNumerator, leftDenominator));
            gcd = policy.Gcd(leftNumerator, gcd);
            var numerator = policy.Divide(leftNumerator, gcd);
            var denominator = policy.Multiply(leftDenominator, policy.Divide(rightDenominator, gcd));
            return (numerator, denominator);
        }

        public static (T Numerator, T Denominator) Divide<T, TPolicy>(
            T leftNumerator, T leftDenominator, T rightNumerator, T rightDenominator, TPolicy policy)
            where TPolicy :
            IAdditiveIdentity<T>,
            IComparer<T>,
            IDivisionFunctions<T>,
            IGreatestCommonDivisorFunctions<T>,
            IMultiplyFunctions<T>,
            IUnaryNegationFunctions<T>
        {
            // https://github.com/boostorg/rational/blob/boost-1.90.0/include/boost/rational.hpp#L586
            if (policy.Compare(rightNumerator, policy.AdditiveIdentity) is 0)
                throw new ArgumentOutOfRangeException(nameof(rightNumerator));
            if (policy.Compare(leftNumerator, policy.AdditiveIdentity) is 0)
                return (leftNumerator, leftDenominator);

            var gcd1 = policy.Gcd(leftNumerator, rightNumerator);
            var gcd2 = policy.Gcd(leftDenominator, rightDenominator);
            var numerator = policy.Multiply(policy.Divide(leftNumerator, gcd1), policy.Divide(rightDenominator, gcd2));
            var denominator =
                policy.Multiply(policy.Divide(leftDenominator, gcd2), policy.Divide(rightNumerator, gcd1));
            if (policy.Compare(denominator, policy.AdditiveIdentity) < 0)
            {
                numerator = policy.Negate(numerator);
                denominator = policy.Negate(denominator);
            }

            return (numerator, denominator);
        }

        public static (T Numerator, T Denominator) Multiply<T, TPolicy>(
            T leftNumerator, T leftDenominator, T rightNumerator, T rightDenominator, TPolicy policy)
            where TPolicy :
            IDivisionFunctions<T>,
            IGreatestCommonDivisorFunctions<T>,
            IMultiplyFunctions<T>
        {
            // https://github.com/boostorg/rational/blob/boost-1.90.0/include/boost/rational.hpp#L571
            var gcd1 = policy.Gcd(leftNumerator, rightDenominator);
            var gcd2 = policy.Gcd(leftDenominator, rightNumerator);
            var numerator = policy.Multiply(policy.Divide(leftNumerator, gcd1), policy.Divide(rightNumerator, gcd2));
            var denominator =
                policy.Multiply(policy.Divide(leftDenominator, gcd2), policy.Divide(rightDenominator, gcd1));
            return (numerator, denominator);
        }

        public static (T Numerator, T Denominator) Subtract<T, TPolicy>(
            T leftNumerator, T leftDenominator, T rightNumerator, T rightDenominator, TPolicy policy)
            where TPolicy :
            IDivisionFunctions<T>,
            IGreatestCommonDivisorFunctions<T>,
            IMultiplyFunctions<T>,
            ISubtractionFunctions<T>
        {
            // https://github.com/boostorg/rational/blob/boost-1.90.0/include/boost/rational.hpp#L552
            var gcd = policy.Gcd(leftDenominator, rightDenominator);
            leftDenominator = policy.Divide(leftDenominator, gcd);
            leftNumerator = policy.Subtract(
                policy.Multiply(leftNumerator, policy.Divide(rightDenominator, gcd)),
                policy.Multiply(rightNumerator, leftDenominator));
            gcd = policy.Gcd(leftNumerator, gcd);
            var numerator = policy.Divide(leftNumerator, gcd);
            var denominator = policy.Multiply(leftDenominator, policy.Divide(rightDenominator, gcd));
            return (numerator, denominator);
        }
    }
}
