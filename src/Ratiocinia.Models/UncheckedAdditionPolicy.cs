namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    public sealed class UncheckedAdditionPolicy<T> :
        IUncheckedAdditionFunctions<T>,
        IUncheckedDivisionFunctions<T>,
        IUncheckedMultiplyFunctions<T>,
        IEquatableGreatestCommonDivisorFunctions<T>
        where T :
        IAdditionOperators<T, T, T>,
        IAdditiveIdentity<T, T>,
        IDivisionOperators<T, T, T>,
        IEquatable<T>,
        IModulusOperators<T, T, T>,
        IMultiplyOperators<T, T, T>
    {
        public static UncheckedAdditionPolicy<T> Instance { get; } = new();
    }
}
