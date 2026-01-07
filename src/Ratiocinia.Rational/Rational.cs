namespace Ratiocinia
{
    using System;
    using System.Globalization;
    using System.Numerics;
    using Algorithms.Specialized;

    public readonly partial struct Rational<T>
        where T :
        IBinaryInteger<T>,
        IComparable<T>,
        IModulusOperators<T, T, T>,
        INumberBase<T>
    {
        private Rational(T numerator, T denominator) => (Numerator, RawDenominator) = (numerator, denominator);

        public T Numerator { get; }

        private T RawDenominator { get; }

        public T Denominator => IsDefault ? T.One : RawDenominator;

        private bool IsDefault => T.AdditiveIdentity.CompareTo(RawDenominator) is 0;

        private static Rational<T> UnsafeCreate(T numerator, T denominator) => new(numerator, denominator);

        public static bool TryCreate(T numerator, T denominator, out Rational<T> rational)
        {
            bool result = NumericRationalOperations.IsNormalized(numerator, denominator);
            rational = result ? UnsafeCreate(numerator, denominator) : AdditiveIdentity;
            return result;
        }

        public static Rational<T> Create(T numerator, T denominator)
        {
            var (normalizedNumerator, normalizedDenominator) =
                CheckedRationalOperations.Normalize(numerator, denominator);
            return UnsafeCreate(normalizedNumerator, normalizedDenominator);
        }

        public override string ToString() => ToString(string.Empty, CultureInfo.InvariantCulture);
    }
}
