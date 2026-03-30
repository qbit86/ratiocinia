namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;
    using System.Runtime.CompilerServices;

    internal static class GreatestCommonDivisor
    {
        private static T Abs<T>(T value)
            where T : IAdditiveIdentity<T, T>, IComparable<T>, IUnaryNegationOperators<T, T> =>
            T.AdditiveIdentity.CompareTo(value) > 0 ? -value : value;

        internal static T GcdComparable<T>(T left, T right)
            where T : IAdditiveIdentity<T, T>, IComparable<T>, IModulusOperators<T, T, T>, IUnaryNegationOperators<T, T>
        {
            var equatable = ComparableEquatableFactory<T>.Create(T.AdditiveIdentity);
            return Gcd(Abs(left), Abs(right), equatable);
        }

        internal static T GcdComparable<T, TComparable>(T left, T right, TComparable identity)
            where T : IAdditiveIdentity<T, T>, IComparable<T>, IModulusOperators<T, T, T>, IUnaryNegationOperators<T, T>
            where TComparable : IComparable<T>
        {
            var equatable = ComparableEquatableFactory<T>.Create(identity);
            return Gcd(Abs(left), Abs(right), equatable);
        }

        internal static T GcdNumberBase<T>(T left, T right)
            where T : IModulusOperators<T, T, T>, INumberBase<T> =>
            Gcd(T.Abs(left), T.Abs(right), default(IsZeroEquatable<T>));

        private static T Gcd<T, TEquatable>(T left, T right, TEquatable identity)
            where T : IModulusOperators<T, T, T>
#if NET9_0_OR_GREATER
            where TEquatable : IEquatable<T>, allows ref struct
#else
            where TEquatable : IEquatable<T>
#endif
        {
            var policy = NumericModulusFunctions<T>.Instance;
            return Algorithms.Generic.GreatestCommonDivisor.GcdUnchecked(left, right, identity, policy);
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

    file sealed class NumericModulusFunctions<T> : INumericModulusFunctions<T> where T : IModulusOperators<T, T, T>
    {
        internal static NumericModulusFunctions<T> Instance { get; } = new();
    }
}
