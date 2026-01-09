namespace Ratiocinia
{
    using System;

    partial struct Rational<T>
    {
        public string ToString(string? format, IFormatProvider? formatProvider) =>
            $"{Numerator.ToString(format, formatProvider)}/{Denominator.ToString(format, formatProvider)}";

        public bool TryFormat(
            Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider) =>
            destination.TryWrite(provider, $"{Numerator}/{Denominator}", out charsWritten);
    }
}
