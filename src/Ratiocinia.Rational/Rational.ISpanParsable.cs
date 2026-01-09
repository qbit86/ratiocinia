namespace Ratiocinia
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;

    partial struct Rational<T>
    {
        public static Rational<T> Parse(string s, IFormatProvider? provider) =>
            Parse(s.AsSpan(), provider);

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out Rational<T> result) =>
            TryParse(s.AsSpan(), provider, out result);

        public static Rational<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider) =>
            Parse(s, NumberStyles.Integer, provider);

        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out Rational<T> result) =>
            TryParseCore(s, NumberStyles.Integer, provider, out result);
    }
}
