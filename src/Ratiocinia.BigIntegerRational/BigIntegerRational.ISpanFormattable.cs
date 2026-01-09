namespace Ratiocinia
{
    using System;
    using Algorithms.Specialized;

    partial struct BigIntegerRational
    {
        public string ToString(string? format, IFormatProvider? formatProvider) =>
            $"{Numerator.ToString(format, formatProvider)}/{Denominator.ToString(format, formatProvider)}";

        public bool TryFormat(
            Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider) =>
            NumericRationalOperations.TryFormat(
                Numerator, Denominator, destination, out charsWritten, format, provider);
    }
}
