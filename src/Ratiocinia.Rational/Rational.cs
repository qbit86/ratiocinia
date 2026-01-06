namespace Ratiocinia
{
    using System;
    using System.Numerics;
    using Algorithms.Specialized;
    using static System.FormattableString;

    public readonly record struct Rational<T>
        where T :
        IAdditiveIdentity<T, T>,
        IComparable<T>,
        IEquatable<T>,
        IModulusOperators<T, T, T>,
        IMultiplicativeIdentity<T, T>,
        INumberBase<T>
    {
        private Rational(T numerator, T denominator) => (Numerator, Denominator) = (numerator, denominator);

        public T Numerator { get; }

        public T Denominator { get; }

        public static Rational<T> AdditiveIdentity { get; } = new(T.AdditiveIdentity, T.MultiplicativeIdentity);

        public static Rational<T> CreateUnsafe(T numerator, T denominator) => new(numerator, denominator);

        public static bool TryCreate(T numerator, T denominator, out Rational<T> rational)
        {
            bool result = NumericRationalOperations.IsNormalized(numerator, denominator);
            rational = result ? new(numerator, denominator) : AdditiveIdentity;
            return result;
        }

        public static Rational<T> Create(T numerator, T denominator) => throw new NotImplementedException();

        public override string ToString() => Invariant($"{Numerator}/{Denominator}");
    }
}
