namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    public interface IEquatableNumberGreatestCommonDivisorFunctions<T> : IGreatestCommonDivisorFunctions<T>
        where T : IAdditiveIdentity<T, T>, IEquatable<T>, IModulusOperators<T, T, T>
    {
        T IGreatestCommonDivisorFunctions<T>.Gcd(T left, T right) => IntegerOperations.GcdEquatable(left, right);
    }
}
