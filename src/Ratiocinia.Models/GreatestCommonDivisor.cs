namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;
    using MathFoundations;

    internal static class GreatestCommonDivisor
    {
        internal static T GcdComparable<T>(T left, T right)
            where T : IAdditiveIdentity<T, T>, IComparable<T>, IModulusOperators<T, T, T>, IUnaryNegationOperators<T, T>
            => GcdComparable(left, right, T.AdditiveIdentity);

        internal static T GcdComparable<T, TComparable>(T left, T right, TComparable identity)
            where T : IAdditiveIdentity<T, T>, IComparable<T>, IModulusOperators<T, T, T>, IUnaryNegationOperators<T, T>
            where TComparable : IComparable<T>
        {
            ComparableGcdPolicy<T, TComparable> policy = new(identity);
            return Algorithms.Generic.Internal.GreatestCommonDivisor.Gcd(left, right, policy);
        }

        internal static T GcdNumberBase<T>(T left, T right)
            where T : IModulusOperators<T, T, T>, INumberBase<T>
        {
            NumberBaseGcdPolicy<T> policy = default;
            return Algorithms.Generic.Internal.GreatestCommonDivisor.Gcd(left, right, policy);
        }
    }

    file readonly struct ComparableGcdPolicy<T, TComparable>(TComparable identity) :
        IAbs<T>,
        IIsAdditiveIdentity<T>,
        IRemainderTruncated<T>
        where T : IAdditiveIdentity<T, T>, IComparable<T>, IModulusOperators<T, T, T>, IUnaryNegationOperators<T, T>
        where TComparable : IComparable<T>
    {
        T IAbs<T>.Abs(T value) => T.AdditiveIdentity.CompareTo(value) > 0 ? -value : value;
        bool IIsAdditiveIdentity<T>.IsAdditiveIdentity(T value) => identity.CompareTo(value) is 0;
        T IRemainderTruncated<T>.RemainderTruncated(T left, T right) => left % right;
    }

    file readonly struct NumberBaseGcdPolicy<T> :
        IAbs<T>,
        IIsAdditiveIdentity<T>,
        IRemainderTruncated<T>
        where T : INumberBase<T>, IModulusOperators<T, T, T>
    {
        T IAbs<T>.Abs(T value) => T.Abs(value);
        bool IIsAdditiveIdentity<T>.IsAdditiveIdentity(T value) => T.IsZero(value);
        T IRemainderTruncated<T>.RemainderTruncated(T left, T right) => left % right;
    }
}
