namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    public interface IComparableNumberGreatestCommonDivisorFunctions<T> : IGreatestCommonDivisorFunctions<T>
        where T : IAdditiveIdentity<T, T>, IComparable<T>, IModulusOperators<T, T, T>
    {
        T IGreatestCommonDivisorFunctions<T>.Gcd(T left, T right) => GreatestCommonDivisor.GcdComparable(left, right);
    }
}
