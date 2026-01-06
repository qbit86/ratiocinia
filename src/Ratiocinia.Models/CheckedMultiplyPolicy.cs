namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    public sealed class CheckedMultiplyPolicy<T> :
        ICheckedDivisionFunctions<T>,
        ICheckedMultiplyFunctions<T>,
        IEquatableGreatestCommonDivisorFunctions<T>
        where T :
        IAdditiveIdentity<T, T>,
        IDivisionOperators<T, T, T>,
        IEquatable<T>,
        IModulusOperators<T, T, T>,
        IMultiplyOperators<T, T, T>
    {
        public static CheckedMultiplyPolicy<T> Instance { get; } = new();
    }
}
