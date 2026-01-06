namespace Ratiocinia
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    partial struct Rational<T> : ISpanParsable<Rational<T>>
    {
        public static Rational<T> Parse(string s, IFormatProvider? provider) => throw new NotImplementedException();

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out Rational<T> result) =>
            throw new NotImplementedException();

        public static Rational<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider) =>
            throw new NotImplementedException();

        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out Rational<T> result) =>
            throw new NotImplementedException();
    }
}
