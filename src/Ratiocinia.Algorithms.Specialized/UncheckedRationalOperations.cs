namespace Ratiocinia.Algorithms.Specialized
{
    using System;
    using System.Numerics;
    using Generic;
    using Models;

    public static class UncheckedRationalOperations
    {
        public static (T Numerator, T Denominator) Add<T>(
            T leftNumerator, T leftDenominator, T rightNumerator, T rightDenominator)
            where T :
            IAdditionOperators<T, T, T>,
            IAdditiveIdentity<T, T>,
            IDivisionOperators<T, T, T>,
            IEquatable<T>,
            IModulusOperators<T, T, T>,
            IMultiplyOperators<T, T, T> =>
            RationalOperations.Add(
                leftNumerator, leftDenominator, rightNumerator, rightDenominator, NumberUncheckedPolicy<T>.Instance);

        public static (BigInteger Numerator, BigInteger Denominator) Add(
            BigInteger leftNumerator, BigInteger leftDenominator, BigInteger rightNumerator,
            BigInteger rightDenominator) =>
            RationalOperations.Add(
                leftNumerator, leftDenominator, rightNumerator, rightDenominator, BigIntegerPolicy.Instance);

        public static (T Numerator, T Denominator) Multiply<T>(
            T leftNumerator, T leftDenominator, T rightNumerator, T rightDenominator)
            where T :
            IAdditionOperators<T, T, T>,
            IAdditiveIdentity<T, T>,
            IDivisionOperators<T, T, T>,
            IEquatable<T>,
            IModulusOperators<T, T, T>,
            IMultiplyOperators<T, T, T> =>
            RationalOperations.Multiply(
                leftNumerator, leftDenominator, rightNumerator, rightDenominator, NumberUncheckedPolicy<T>.Instance);

        public static (BigInteger Numerator, BigInteger Denominator) Multiply(
            BigInteger leftNumerator, BigInteger leftDenominator, BigInteger rightNumerator,
            BigInteger rightDenominator) =>
            RationalOperations.Multiply(
                leftNumerator, leftDenominator, rightNumerator, rightDenominator, BigIntegerPolicy.Instance);
    }
}
