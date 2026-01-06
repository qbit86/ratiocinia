namespace Ratiocinia.Algorithms.Specialized
{
    using System;
    using System.Numerics;
    using Generic;
    using Models;

    public static class CheckedRationalOperations
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
                leftNumerator, leftDenominator, rightNumerator, rightDenominator,
                NumberCheckedAdditionPolicy<T>.Instance);

        public static (T Numerator, T Denominator) Divide<T>(
            T leftNumerator, T leftDenominator, T rightNumerator, T rightDenominator)
            where T :
            IAdditiveIdentity<T, T>,
            IDivisionOperators<T, T, T>,
            IComparable<T>,
            IModulusOperators<T, T, T>,
            IMultiplyOperators<T, T, T>,
            IUnaryNegationOperators<T, T> =>
            RationalOperations.Divide(
                leftNumerator, leftDenominator, rightNumerator, rightDenominator,
                T.AdditiveIdentity, NumberCheckedDivisionPolicy<T>.Instance);

        public static (T Numerator, T Denominator) Multiply<T>(
            T leftNumerator, T leftDenominator, T rightNumerator, T rightDenominator)
            where T :
            IAdditiveIdentity<T, T>,
            IDivisionOperators<T, T, T>,
            IEquatable<T>,
            IModulusOperators<T, T, T>,
            IMultiplyOperators<T, T, T> =>
            RationalOperations.Multiply(
                leftNumerator, leftDenominator, rightNumerator, rightDenominator,
                NumberCheckedMultiplyPolicy<T>.Instance);

        public static (T Numerator, T Denominator) Subtract<T>(
            T leftNumerator, T leftDenominator, T rightNumerator, T rightDenominator)
            where T :
            IAdditiveIdentity<T, T>,
            IDivisionOperators<T, T, T>,
            IEquatable<T>,
            IModulusOperators<T, T, T>,
            IMultiplyOperators<T, T, T>,
            ISubtractionOperators<T, T, T> =>
            RationalOperations.Subtract(
                leftNumerator, leftDenominator, rightNumerator, rightDenominator,
                NumberCheckedSubtractionPolicy<T>.Instance);
    }
}
