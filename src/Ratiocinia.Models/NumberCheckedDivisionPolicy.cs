namespace Ratiocinia.Models
{
    using System;
    using System.Collections.Generic;
    using System.Numerics;

    public sealed class NumberCheckedDivisionPolicy<T> :
        ICheckedDivisionFunctions<T>,
        ICheckedMultiplyFunctions<T>,
        ICheckedUnaryNegationFunctions<T>,
        IComparableNumberGreatestCommonDivisorFunctions<T>,
        IComparer<T>,
        INumberAdditiveIdentity<T>
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
}
