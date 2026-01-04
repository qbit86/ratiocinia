namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    public sealed class NumberCheckedMultiplyPolicy<T> :
        ICheckedDivisionFunctions<T>,
        ICheckedMultiplyFunctions<T>,
        IEquatableNumberGreatestCommonDivisorFunctions<T>
        where T :
        IAdditiveIdentity<T, T>,
        IDivisionOperators<T, T, T>,
        IEquatable<T>,
        IModulusOperators<T, T, T>,
        IMultiplyOperators<T, T, T>
    {
        public static NumberCheckedMultiplyPolicy<T> Instance { get; } = new();
    }
}
