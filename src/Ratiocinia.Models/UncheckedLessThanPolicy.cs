namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    public sealed class UncheckedLessThanPolicy<T> :
        IComparableComparer<T>,
        INumericModulusFunctions<T>,
        IUncheckedAdditionFunctions<T>,
        IUncheckedDecrementFunctions<T>,
        IUncheckedDivisionFunctions<T>
        where T :
        IAdditionOperators<T, T, T>,
        IComparable<T>,
        IDecrementOperators<T>,
        IDivisionOperators<T, T, T>,
        IModulusOperators<T, T, T>
    {
        public static UncheckedLessThanPolicy<T> Instance { get; } = new();
    }
}
