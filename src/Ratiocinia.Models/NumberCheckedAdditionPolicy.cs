namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    public sealed class NumberCheckedAdditionPolicy<T> :
        ICheckedAdditionFunctions<T>,
        ICheckedDivisionFunctions<T>,
        ICheckedMultiplyFunctions<T>,
        IEquatableNumberGreatestCommonDivisorFunctions<T>
        where T :
        IAdditionOperators<T, T, T>,
        IAdditiveIdentity<T, T>,
        IDivisionOperators<T, T, T>,
        IEquatable<T>,
        IModulusOperators<T, T, T>,
        IMultiplyOperators<T, T, T>
    {
        public static NumberCheckedAdditionPolicy<T> Instance { get; } = new();
    }
}
