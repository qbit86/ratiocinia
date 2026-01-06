namespace Ratiocinia.Algorithms.Generic
{
    using System;
    using System.Diagnostics;

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

        public static (T Numerator, T Denominator) Divide<T, TAdditiveIdentity, TPolicy>(
            T leftNumerator,
            T leftDenominator,
            T rightNumerator,
            T rightDenominator,
            TAdditiveIdentity additiveIdentity,
            TPolicy policy)
            where TAdditiveIdentity : IComparable<T>
            where TPolicy :
            IDivisionFunctions<T>,
            IGreatestCommonDivisorFunctions<T>,
            IMultiplyFunctions<T>,
            IUnaryNegationFunctions<T>
        {
            Debug.Assert(additiveIdentity.CompareTo(leftDenominator) < 0);
            Debug.Assert(additiveIdentity.CompareTo(rightDenominator) < 0);

            // https://github.com/boostorg/rational/blob/boost-1.90.0/include/boost/rational.hpp#L586
            if (additiveIdentity.CompareTo(rightNumerator) is 0)
                throw new ArgumentOutOfRangeException(nameof(rightNumerator));
            if (additiveIdentity.CompareTo(leftNumerator) is 0)
                return (leftNumerator, leftDenominator);

            var gcd1 = policy.Gcd(leftNumerator, rightNumerator);
            var gcd2 = policy.Gcd(leftDenominator, rightDenominator);
            var numerator = policy.Multiply(policy.Divide(leftNumerator, gcd1), policy.Divide(rightDenominator, gcd2));
            var denominator =
                policy.Multiply(policy.Divide(leftDenominator, gcd2), policy.Divide(rightNumerator, gcd1));
            if (additiveIdentity.CompareTo(denominator) > 0)
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

        public static (T Numerator, T Denominator) Negate<T, TPolicy>(T numerator, T denominator, TPolicy policy)
            where TPolicy : IUnaryNegationFunctions<T> =>
            (policy.Negate(numerator), denominator);

        public static bool IsNormalized<T, TAdditiveIdentity, TMultiplicativeIdentity, TPolicy>(
            T numerator,
            T denominator,
            TAdditiveIdentity additiveIdentity,
            TMultiplicativeIdentity multiplicativeIdentity,
            TPolicy policy)
            where TAdditiveIdentity : IComparable<T>
            where TMultiplicativeIdentity : IEquatable<T>
            where TPolicy : IAbsoluteFunctions<T>, IGreatestCommonDivisorFunctions<T>
        {
            // https://github.com/boostorg/rational/blob/boost-1.90.0/include/boost/rational.hpp#L430
            if (additiveIdentity.CompareTo(denominator) >= 0)
                return false;

            if (additiveIdentity.CompareTo(numerator) is 0 && !multiplicativeIdentity.Equals(denominator))
                return false;

            var gcd = policy.Gcd(numerator, denominator);
            var abs = policy.Abs(gcd);
            return multiplicativeIdentity.Equals(abs);
        }
    }
}
