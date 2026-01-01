namespace Ratiocinia.Algorithms.Specialized
{
    using System.Numerics;
    using Models;

    public static class CheckedRationalOperations
    {
        public static (T Numerator, T Denominator) Add<T>(
            T leftNumerator, T leftDenominator, T rightNumerator, T rightDenominator)
            where T :
            IAdditionOperators<T, T, T>,
            IDivisionOperators<T, T, T>,
            IMultiplyOperators<T, T, T> =>
            Generic.RationalOperations.Add(
                leftNumerator, leftDenominator, rightNumerator, rightDenominator, NumberCheckedPolicy<T>.Instance);
    }
}
