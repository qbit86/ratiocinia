namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    public interface INumberPolicy<T> :
        IPartialNumberPolicy<T>,
        IGreatestCommonDivisorFunctions<T>
        where T :
        IAdditionOperators<T, T, T>,
        IDivisionOperators<T, T, T>,
        IMultiplyOperators<T, T, T>
    {
        T IGreatestCommonDivisorFunctions<T>.Gcd(T left, T right) => throw new NotImplementedException();
    }

    public sealed class NumberPolicy<T> : INumberPolicy<T>
        where T :
        IAdditionOperators<T, T, T>,
        IDivisionOperators<T, T, T>,
        IMultiplyOperators<T, T, T>
    {
        public static NumberPolicy<T> Instance { get; } = new();
    }
}
