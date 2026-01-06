namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    public sealed class NumberCheckedDivisionPolicy<T> :
        ICheckedDivisionFunctions<T>,
        ICheckedMultiplyFunctions<T>,
        ICheckedUnaryNegationFunctions<T>,
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
    }
}
