namespace Ratiocinia
{
    using System;

    partial struct Rational<T> : ISpanFormattable
    {
        public string ToString(string? format, IFormatProvider? formatProvider)
        {
            FormattableString formattable = $"{Numerator}/{Denominator}";
            return formattable.ToString(formatProvider);
        }

        public bool TryFormat(
            Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider) =>
            destination.TryWrite(provider, $"{Numerator}/{Denominator}", out charsWritten);
    }
}
