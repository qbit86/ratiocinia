namespace Ratiocinia
{
    using System;
    using Algorithms.Specialized;

    partial struct BigIntegerRational
    {
        /// <summary>
        /// Formats the rational number as a string.
        /// </summary>
        /// <param name="format">The format string to use, or <see langword="null" /> for the default format.</param>
        /// <param name="formatProvider">The provider to use to format the value, or <see langword="null" /> for the default.</param>
        /// <returns>A string representation of the rational number in the format "numerator/denominator".</returns>
        public string ToString(string? format, IFormatProvider? formatProvider) =>
            $"{Numerator.ToString(format, formatProvider)}/{Denominator.ToString(format, formatProvider)}";

        /// <summary>
        /// Attempts to format the rational number into the provided character span.
        /// </summary>
        /// <param name="destination">The span in which to write the formatted value.</param>
        /// <param name="charsWritten">When this method returns, contains the number of characters written to <paramref name="destination" />.</param>
        /// <param name="format">A span containing the format string to use.</param>
        /// <param name="provider">The provider to use to format the value.</param>
        /// <returns>
        /// <see langword="true" /> if the formatting was successful; otherwise, <see langword="false" />.
        /// </returns>
        public bool TryFormat(
            Span<char> destination, out int charsWritten, ReadOnlySpan<char> format, IFormatProvider? provider) =>
            NumericRationalOperations.TryFormat(
                Numerator, Denominator, destination, out charsWritten, format, provider);
    }
}
