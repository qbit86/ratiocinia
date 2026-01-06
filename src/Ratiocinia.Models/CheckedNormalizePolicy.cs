namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    public sealed class CheckedNormalizePolicy<T> :
        ICheckedDivisionFunctions<T>,
        ICheckedUnaryNegationFunctions<T>,
        IComparableGreatestCommonDivisorFunctions<T>
        where T :
        IAdditiveIdentity<T, T>,
        IDivisionOperators<T, T, T>,
        IComparable<T>,
        IModulusOperators<T, T, T>,
        IUnaryNegationOperators<T, T>
    {
        public static CheckedNormalizePolicy<T> Instance { get; } = new();
    }
}
