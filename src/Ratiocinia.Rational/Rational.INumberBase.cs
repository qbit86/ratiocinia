namespace Ratiocinia
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Numerics;

    partial struct Rational<T> : INumberBase<Rational<T>>
    {
        public static Rational<T> Abs(Rational<T> value) => throw new NotImplementedException();

        public static bool IsCanonical(Rational<T> value) => throw new NotImplementedException();

        public static bool IsComplexNumber(Rational<T> value) => throw new NotImplementedException();

        public static bool IsEvenInteger(Rational<T> value) => throw new NotImplementedException();

        public static bool IsFinite(Rational<T> value) => throw new NotImplementedException();

        public static bool IsImaginaryNumber(Rational<T> value) => throw new NotImplementedException();

        public static bool IsInfinity(Rational<T> value) => throw new NotImplementedException();

        public static bool IsInteger(Rational<T> value) => throw new NotImplementedException();

        public static bool IsNaN(Rational<T> value) => throw new NotImplementedException();

        public static bool IsNegative(Rational<T> value) => throw new NotImplementedException();

        public static bool IsNegativeInfinity(Rational<T> value) => throw new NotImplementedException();

        public static bool IsNormal(Rational<T> value) => throw new NotImplementedException();

        public static bool IsOddInteger(Rational<T> value) => throw new NotImplementedException();

        public static bool IsPositive(Rational<T> value) => throw new NotImplementedException();

        public static bool IsPositiveInfinity(Rational<T> value) => throw new NotImplementedException();

        public static bool IsRealNumber(Rational<T> value) => throw new NotImplementedException();

        public static bool IsSubnormal(Rational<T> value) => throw new NotImplementedException();

        public static bool IsZero(Rational<T> value) => throw new NotImplementedException();

        public static Rational<T> MaxMagnitude(Rational<T> x, Rational<T> y) => throw new NotImplementedException();

        public static Rational<T> MaxMagnitudeNumber(Rational<T> x, Rational<T> y) =>
            throw new NotImplementedException();

        public static Rational<T> MinMagnitude(Rational<T> x, Rational<T> y) => throw new NotImplementedException();

        public static Rational<T> MinMagnitudeNumber(Rational<T> x, Rational<T> y) =>
            throw new NotImplementedException();

        public static Rational<T> Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider) =>
            throw new NotImplementedException();

        public static Rational<T> Parse(string s, NumberStyles style, IFormatProvider? provider) =>
            throw new NotImplementedException();

        public static bool TryConvertFromChecked<TOther>(TOther value, out Rational<T> result)
            where TOther : INumberBase<TOther> => throw new NotImplementedException();

        public static bool TryConvertFromSaturating<TOther>(TOther value, out Rational<T> result)
            where TOther : INumberBase<TOther> => throw new NotImplementedException();

        public static bool TryConvertFromTruncating<TOther>(TOther value, out Rational<T> result)
            where TOther : INumberBase<TOther> => throw new NotImplementedException();

        public static bool TryConvertToChecked<TOther>(Rational<T> value, [MaybeNullWhen(false)] out TOther result)
            where TOther : INumberBase<TOther> => throw new NotImplementedException();

        public static bool TryConvertToSaturating<TOther>(Rational<T> value, [MaybeNullWhen(false)] out TOther result)
            where TOther : INumberBase<TOther> => throw new NotImplementedException();

        public static bool TryConvertToTruncating<TOther>(Rational<T> value, [MaybeNullWhen(false)] out TOther result)
            where TOther : INumberBase<TOther> => throw new NotImplementedException();

        public static bool TryParse(
            ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out Rational<T> result) =>
            throw new NotImplementedException();

        public static bool TryParse([NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider,
            out Rational<T> result) => throw new NotImplementedException();

        public static Rational<T> One => MultiplicativeIdentity;

        public static int Radix => T.Radix;

        public static Rational<T> Zero => AdditiveIdentity;
    }
}
