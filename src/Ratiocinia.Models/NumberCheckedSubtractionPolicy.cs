namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    public sealed class NumberCheckedSubtractionPolicy<T> :
        ICheckedDivisionFunctions<T>,
        ICheckedMultiplyFunctions<T>,
        ICheckedSubtractionFunctions<T>,
        IEquatableNumberGreatestCommonDivisorFunctions<T>
        where T :
        IAdditiveIdentity<T, T>,
        IDivisionOperators<T, T, T>,
        IEquatable<T>,
        IModulusOperators<T, T, T>,
        IMultiplyOperators<T, T, T>,
        ISubtractionOperators<T, T, T>
    {
        public static NumberCheckedSubtractionPolicy<T> Instance { get; } = new();
    }
}
