namespace Ratiocinia
{
    using System;

    partial struct Rational<T>
    {
        public string ToString(string? format, IFormatProvider? formatProvider) =>
            $"{Numerator.ToString(format, formatProvider)}/{Denominator.ToString(format, formatProvider)}";

        public bool TryFormat(
            Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider)
        {
            charsWritten = 0;

            if (!Numerator.TryFormat(destination, out int numeratorCharsWritten, format, provider))
                return false;

            int offset = numeratorCharsWritten;
            if (offset >= destination.Length)
                return false;

            destination[offset] = '/';
            offset++;

            if (!Denominator.TryFormat(destination[offset..], out int denominatorCharsWritten, format, provider))
                return false;

            charsWritten = offset + denominatorCharsWritten;
            return true;
        }
    }
}
