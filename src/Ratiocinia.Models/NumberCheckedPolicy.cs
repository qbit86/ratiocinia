namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    public sealed class NumberCheckedPolicy<T> :
        IPartialNumberCheckedPolicy<T>,
        IGreatestCommonDivisorFunctionsImplementation<T>
        where T :
        IAdditionOperators<T, T, T>,
        IAdditiveIdentity<T, T>,
        IDivisionOperators<T, T, T>,
        IEquatable<T>,
        IModulusOperators<T, T, T>,
        IMultiplyOperators<T, T, T>
    {
        public static NumberCheckedPolicy<T> Instance { get; } = new();
    }
}
