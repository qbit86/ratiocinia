namespace Ratiocinia
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;

    partial struct BigIntegerRational
    {
        public static BigIntegerRational Parse(string s, IFormatProvider? provider) =>
            Parse(s.AsSpan(), provider);

        public static bool TryParse(
            [NotNullWhen(true)] string? s, IFormatProvider? provider, out BigIntegerRational result) =>
            TryParse(s.AsSpan(), provider, out result);

        public static BigIntegerRational Parse(ReadOnlySpan<char> s, IFormatProvider? provider) =>
            Parse(s, NumberStyles.Integer, provider);

        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out BigIntegerRational result) =>
            TryParseCore(s, NumberStyles.Integer, provider, out result);
    }
}
