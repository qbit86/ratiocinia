namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    public sealed class CheckedSubtractionPolicy<T> :
        ICheckedDivisionFunctions<T>,
        ICheckedMultiplyFunctions<T>,
        ICheckedSubtractionFunctions<T>,
        IEquatableGreatestCommonDivisorFunctions<T>
        where T :
        IAdditiveIdentity<T, T>,
        IDivisionOperators<T, T, T>,
        IEquatable<T>,
        IModulusOperators<T, T, T>,
        IMultiplyOperators<T, T, T>,
        ISubtractionOperators<T, T, T>
    {
        public static CheckedSubtractionPolicy<T> Instance { get; } = new();
    }
}
