namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    public sealed class CheckedLessThanPolicy<T> :
        IBinaryDivRemFunctions<T>,
        ICheckedAdditionFunctions<T>,
        ICheckedDecrementFunctions<T>,
        IComparableComparer<T>
        where T :
        IAdditionOperators<T, T, T>,
        IBinaryInteger<T>,
        IComparable<T>,
        IDecrementOperators<T>,
        IDivisionOperators<T, T, T>,
        IModulusOperators<T, T, T>
    {
        public static CheckedLessThanPolicy<T> Instance { get; } = new();
    }
}
