namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    public interface INumberCheckedPolicy<T> :
        IPartialNumberCheckedPolicy<T>,
        IGreatestCommonDivisorFunctions<T>
        where T :
        IAdditionOperators<T, T, T>,
        IDivisionOperators<T, T, T>,
        IMultiplyOperators<T, T, T>
    {
        T IGreatestCommonDivisorFunctions<T>.Gcd(T left, T right) => throw new NotImplementedException();
    }

    public sealed class NumberCheckedPolicy<T> : INumberCheckedPolicy<T>
        where T :
        IAdditionOperators<T, T, T>,
        IDivisionOperators<T, T, T>,
        IMultiplyOperators<T, T, T>
    {
        public static NumberCheckedPolicy<T> Instance { get; } = new();
    }
}
