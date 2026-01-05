namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;
    using System.Runtime.CompilerServices;

    internal static class GreatestCommonDivisor
    {
        internal static T GcdEquatable<T>(T left, T right)
            where T : IAdditiveIdentity<T, T>, IEquatable<T>, IModulusOperators<T, T, T> =>
            Gcd(left, right, T.AdditiveIdentity);

        internal static T GcdEquatable<T, TEquatable>(T left, T right, TEquatable identity)
            where T : IModulusOperators<T, T, T>
            where TEquatable : IEquatable<T> =>
            Gcd(left, right, identity);

        internal static T GcdComparable<T>(T left, T right)
            where T : IAdditiveIdentity<T, T>, IComparable<T>, IModulusOperators<T, T, T>
        {
            var equatable = ComparableEquatableFactory<T>.Create(T.AdditiveIdentity);
            return Gcd(left, right, equatable);
        }

        internal static T GcdComparable<T, TComparable>(T left, T right, TComparable identity)
            where T : IModulusOperators<T, T, T>
            where TComparable : IComparable<T>
        {
            var equatable = ComparableEquatableFactory<T>.Create(identity);
            return Gcd(left, right, equatable);
        }

        internal static T GcdNumberBase<T>(T left, T right)
            where T : IModulusOperators<T, T, T>, INumberBase<T> =>
            Gcd(left, right, default(IsZeroEquatable<T>));

        private static T Gcd<T, TEquatable>(T left, T right, TEquatable identity)
            where T : IModulusOperators<T, T, T>
#if NET9_0_OR_GREATER
            where TEquatable : IEquatable<T>, allows ref struct
#else
            where TEquatable : IEquatable<T>
#endif
        {
            // https://github.com/boostorg/rational/blob/boost-1.90.0/include/boost/rational.hpp#L414
            // return identity.Equals(right) ? left : Gcd(right, left % right, identity);
            while (true)
            {
                if (identity.Equals(right))
                    return left;
                (left, right) = (right, left % right);
            }
        }
    }

    file static class ComparableEquatableFactory<T>
    {
        internal static ComparableEquatable<T, TComparable> Create<TComparable>(TComparable comparable)
            where TComparable : IComparable<T>
            => new(comparable);
    }

#if NET9_0_OR_GREATER
    file readonly ref struct ComparableEquatable<T, TComparable>(TComparable comparable) : IEquatable<T>
#else
    file readonly struct ComparableEquatable<T, TComparable>(TComparable comparable) : IEquatable<T>
#endif
        where TComparable : IComparable<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(T? other) => comparable.CompareTo(other) is 0;
    }

    file readonly struct IsZeroEquatable<T> : IEquatable<T>
        where T : INumberBase<T>
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public bool Equals(T? other) => other is null || T.IsZero(other);
    }
}
