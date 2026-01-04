namespace Ratiocinia.Algorithms.Specialized
{
    using System;
    using System.Collections.Generic;
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
                leftNumerator, leftDenominator, rightNumerator, rightDenominator,
                NumberUncheckedAdditionPolicy<T>.Instance);

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
                NumberUncheckedDivisionPolicy<T>.Instance);

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
                NumberUncheckedMultiplyPolicy<T>.Instance);

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
                NumberUncheckedSubtractionPolicy<T>.Instance);

        private sealed class NumberUncheckedAdditionPolicy<T> :
            IUncheckedAdditionFunctions<T>,
            IUncheckedDivisionFunctions<T>,
            IUncheckedMultiplyFunctions<T>,
            IEquatableNumberGreatestCommonDivisorFunctions<T>
            where T :
            IAdditionOperators<T, T, T>,
            IAdditiveIdentity<T, T>,
            IDivisionOperators<T, T, T>,
            IEquatable<T>,
            IModulusOperators<T, T, T>,
            IMultiplyOperators<T, T, T>
        {
            public static NumberUncheckedAdditionPolicy<T> Instance { get; } = new();
        }

        private sealed class NumberUncheckedDivisionPolicy<T> :
            IUncheckedDivisionFunctions<T>,
            IUncheckedMultiplyFunctions<T>,
            IUncheckedUnaryNegationFunctions<T>,
            IComparer<T>,
            INumberAdditiveIdentity<T>,
            IComparableNumberGreatestCommonDivisorFunctions<T>
            where T :
            IAdditiveIdentity<T, T>,
            IDivisionOperators<T, T, T>,
            IComparable<T>,
            IModulusOperators<T, T, T>,
            IMultiplyOperators<T, T, T>,
            IUnaryNegationOperators<T, T>
        {
            public static NumberUncheckedDivisionPolicy<T> Instance { get; } = new();

            int IComparer<T>.Compare(T? x, T? y) => Comparer<T>.Default.Compare(x, y);
        }

        private sealed class NumberUncheckedMultiplyPolicy<T> :
            IUncheckedDivisionFunctions<T>,
            IUncheckedMultiplyFunctions<T>,
            IEquatableNumberGreatestCommonDivisorFunctions<T>
            where T :
            IAdditiveIdentity<T, T>,
            IDivisionOperators<T, T, T>,
            IEquatable<T>,
            IModulusOperators<T, T, T>,
            IMultiplyOperators<T, T, T>
        {
            public static NumberUncheckedMultiplyPolicy<T> Instance { get; } = new();
        }

        private sealed class NumberUncheckedSubtractionPolicy<T> :
            IUncheckedDivisionFunctions<T>,
            IUncheckedMultiplyFunctions<T>,
            IUncheckedSubtractionFunctions<T>,
            IEquatableNumberGreatestCommonDivisorFunctions<T>
            where T :
            IAdditiveIdentity<T, T>,
            IDivisionOperators<T, T, T>,
            IEquatable<T>,
            IModulusOperators<T, T, T>,
            IMultiplyOperators<T, T, T>,
            ISubtractionOperators<T, T, T>
        {
            public static NumberUncheckedSubtractionPolicy<T> Instance { get; } = new();
        }
    }
}
