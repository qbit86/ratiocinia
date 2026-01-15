namespace Ratiocinia
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;

    partial struct Rational<T>
    {
        /// <summary>
        /// Parses a string into a rational number using the specified format provider.
        /// </summary>
        /// <param name="s">The string to parse.</param>
        /// <param name="provider">An object that provides culture-specific formatting information.</param>
        /// <returns>The parsed rational number.</returns>
        /// <exception cref="FormatException">Thrown when <paramref name="s" /> is not in a valid format.</exception>
        public static Rational<T> Parse(string s, IFormatProvider? provider) =>
            Parse(s.AsSpan(), provider);

        /// <summary>
        /// Attempts to parse a string into a rational number.
        /// </summary>
        /// <param name="s">The string to parse.</param>
        /// <param name="provider">An object that provides culture-specific formatting information.</param>
        /// <param name="result">
        /// When this method returns, contains the parsed rational number if parsing succeeded;
        /// otherwise, the additive identity.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="s" /> was parsed successfully; otherwise, <see langword="false" />.
        /// </returns>
        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out Rational<T> result) =>
            TryParse(s.AsSpan(), provider, out result);

        /// <summary>
        /// Parses a character span into a rational number using the specified format provider.
        /// </summary>
        /// <param name="s">The character span to parse.</param>
        /// <param name="provider">An object that provides culture-specific formatting information.</param>
        /// <returns>The parsed rational number.</returns>
        /// <exception cref="FormatException">Thrown when <paramref name="s" /> is not in a valid format.</exception>
        public static Rational<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider) =>
            Parse(s, NumberStyles.Integer, provider);

        /// <summary>
        /// Attempts to parse a character span into a rational number.
        /// </summary>
        /// <param name="s">The character span to parse.</param>
        /// <param name="provider">An object that provides culture-specific formatting information.</param>
        /// <param name="result">
        /// When this method returns, contains the parsed rational number if parsing succeeded;
        /// otherwise, the additive identity.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="s" /> was parsed successfully; otherwise, <see langword="false" />.
        /// </returns>
        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out Rational<T> result) =>
            TryParseCore(s, NumberStyles.Integer, provider, out result);
    }
}
