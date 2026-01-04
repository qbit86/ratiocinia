namespace Ratiocinia.Algorithms.Specialized
{
    using System;
    using System.Collections.Generic;
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
                NumberCheckedDivisionPolicy<T>.Instance);

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

        private sealed class NumberCheckedAdditionPolicy<T> :
            ICheckedAdditionFunctions<T>,
            ICheckedDivisionFunctions<T>,
            ICheckedMultiplyFunctions<T>,
            IEquatableNumberGreatestCommonDivisorFunctions<T>
            where T :
            IAdditionOperators<T, T, T>,
            IAdditiveIdentity<T, T>,
            IDivisionOperators<T, T, T>,
            IEquatable<T>,
            IModulusOperators<T, T, T>,
            IMultiplyOperators<T, T, T>
        {
            public static NumberCheckedAdditionPolicy<T> Instance { get; } = new();
        }

        private sealed class NumberCheckedDivisionPolicy<T> :
            ICheckedDivisionFunctions<T>,
            ICheckedMultiplyFunctions<T>,
            ICheckedUnaryNegationFunctions<T>,
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
            public static NumberCheckedDivisionPolicy<T> Instance { get; } = new();

            int IComparer<T>.Compare(T? x, T? y) => Comparer<T>.Default.Compare(x, y);
        }

        private sealed class NumberCheckedMultiplyPolicy<T> :
            ICheckedDivisionFunctions<T>,
            ICheckedMultiplyFunctions<T>,
            IEquatableNumberGreatestCommonDivisorFunctions<T>
            where T :
            IAdditiveIdentity<T, T>,
            IDivisionOperators<T, T, T>,
            IEquatable<T>,
            IModulusOperators<T, T, T>,
            IMultiplyOperators<T, T, T>
        {
            public static NumberCheckedMultiplyPolicy<T> Instance { get; } = new();
        }

        private sealed class NumberCheckedSubtractionPolicy<T> :
            ICheckedDivisionFunctions<T>,
            ICheckedMultiplyFunctions<T>,
            ICheckedSubtractionFunctions<T>,
            IEquatableNumberGreatestCommonDivisorFunctions<T>
            where T :
            IAdditiveIdentity<T, T>,
            IDivisionOperators<T, T, T>,
            IEquatable<T>,
            IModulusOperators<T, T, T>,
            IMultiplyOperators<T, T, T>,
            ISubtractionOperators<T, T, T>
        {
            public static NumberCheckedSubtractionPolicy<T> Instance { get; } = new();
        }
    }
}
