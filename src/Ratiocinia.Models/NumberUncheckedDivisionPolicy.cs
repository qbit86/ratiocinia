namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    public sealed class NumberUncheckedDivisionPolicy<T> :
        IAdditiveIdentityComparer<T>,
        IComparableNumberGreatestCommonDivisorFunctions<T>,
        IUncheckedDivisionFunctions<T>,
        IUncheckedMultiplyFunctions<T>,
        IUncheckedUnaryNegationFunctions<T>
        where T :
        IAdditiveIdentity<T, T>,
        IDivisionOperators<T, T, T>,
        IComparable<T>,
        IModulusOperators<T, T, T>,
        IMultiplyOperators<T, T, T>,
        IUnaryNegationOperators<T, T>
    {
        public static NumberUncheckedDivisionPolicy<T> Instance { get; } = new();
    }
}
