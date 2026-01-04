namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    public sealed class NumberUncheckedMultiplyPolicy<T> :
        IEquatableNumberGreatestCommonDivisorFunctions<T>,
        IUncheckedDivisionFunctions<T>,
        IUncheckedMultiplyFunctions<T>
        where T :
        IAdditiveIdentity<T, T>,
        IDivisionOperators<T, T, T>,
        IEquatable<T>,
        IModulusOperators<T, T, T>,
        IMultiplyOperators<T, T, T>
    {
        public static NumberUncheckedMultiplyPolicy<T> Instance { get; } = new();
    }
}
