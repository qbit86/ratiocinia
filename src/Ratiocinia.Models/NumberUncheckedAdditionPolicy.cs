namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    public sealed class NumberUncheckedAdditionPolicy<T> :
        IUncheckedAdditionFunctions<T>,
        IUncheckedDivisionFunctions<T>,
        IUncheckedMultiplyFunctions<T>,
        IEquatableNumberGreatestCommonDivisorFunctions<T>
        where T :
        IAdditionOperators<T, T, T>,
        IAdditiveIdentity<T, T>,
        IDivisionOperators<T, T, T>,
        IEquatable<T>,
        IModulusOperators<T, T, T>,
        IMultiplyOperators<T, T, T>
    {
        public static NumberUncheckedAdditionPolicy<T> Instance { get; } = new();
    }
}
