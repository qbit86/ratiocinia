namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    public sealed class UncheckedLessThanPolicy<T> :
        IBinaryDivRemFunctions<T>,
        IComparableComparer<T>,
        IUncheckedAdditionFunctions<T>,
        IUncheckedDecrementFunctions<T>
        where T :
        IAdditionOperators<T, T, T>,
        IBinaryInteger<T>,
        IComparable<T>,
        IDecrementOperators<T>,
        IDivisionOperators<T, T, T>,
        IModulusOperators<T, T, T>
    {
        public static UncheckedLessThanPolicy<T> Instance { get; } = new();
    }
}
