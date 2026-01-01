namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    public interface IGreatestCommonDivisorFunctionsImplementation<T> : IGreatestCommonDivisorFunctions<T>
        where T : IAdditiveIdentity<T, T>, IEquatable<T>, IModulusOperators<T, T, T>
    {
        T IGreatestCommonDivisorFunctions<T>.Gcd(T left, T right) =>
            right.Equals(T.AdditiveIdentity) ? left : Gcd(right, left % right);
    }
}
