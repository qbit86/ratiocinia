namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    public sealed class UncheckedSubtractionPolicy<T> :
        IEquatableGreatestCommonDivisorFunctions<T>,
        IUncheckedDivisionFunctions<T>,
        IUncheckedMultiplyFunctions<T>,
        IUncheckedSubtractionFunctions<T>
        where T :
        IAdditiveIdentity<T, T>,
        IDivisionOperators<T, T, T>,
        IEquatable<T>,
        IModulusOperators<T, T, T>,
        IMultiplyOperators<T, T, T>,
        ISubtractionOperators<T, T, T>
    {
        public static UncheckedSubtractionPolicy<T> Instance { get; } = new();
    }
}
