namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    public sealed class UncheckedNormalizePolicy<T> :
        IComparableGreatestCommonDivisorFunctions<T>,
        IUncheckedDivisionFunctions<T>,
        IUncheckedUnaryNegationFunctions<T>
        where T :
        IAdditiveIdentity<T, T>,
        IDivisionOperators<T, T, T>,
        IComparable<T>,
        IModulusOperators<T, T, T>,
        IUnaryNegationOperators<T, T>
    {
        public static UncheckedNormalizePolicy<T> Instance { get; } = new();
    }
}
