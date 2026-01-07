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
            TryParse(s, provider, out var result)
                ? result
                : throw new FormatException("The input string was not in a correct format.");

        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out Rational<T> result) =>
            TryParseCore(s, NumberStyles.None, provider, out result);
    }
}
