namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    public interface INumberUncheckedPolicy<T> :
        IPartialNumberUncheckedPolicy<T>,
        IGreatestCommonDivisorFunctions<T>
        where T :
        IAdditionOperators<T, T, T>,
        IDivisionOperators<T, T, T>,
        IMultiplyOperators<T, T, T>
    {
        T IGreatestCommonDivisorFunctions<T>.Gcd(T left, T right) => throw new NotImplementedException();
    }

    public sealed class NumberUncheckedPolicy<T> : INumberUncheckedPolicy<T>
        where T :
        IAdditionOperators<T, T, T>,
        IDivisionOperators<T, T, T>,
        IMultiplyOperators<T, T, T>
    {
        public static NumberUncheckedPolicy<T> Instance { get; } = new();
    }
}
