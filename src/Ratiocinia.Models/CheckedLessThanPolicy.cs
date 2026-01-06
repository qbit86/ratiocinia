namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    public sealed class CheckedLessThanPolicy<T> :
        ICheckedAdditionFunctions<T>,
        ICheckedDecrementFunctions<T>,
        ICheckedDivisionFunctions<T>,
        IComparableComparer<T>,
        INumericModulusFunctions<T>
        where T :
        IAdditionOperators<T, T, T>,
        IComparable<T>,
        IDecrementOperators<T>,
        IDivisionOperators<T, T, T>,
        IModulusOperators<T, T, T>
    {
        public static CheckedLessThanPolicy<T> Instance { get; } = new();
    }
}
