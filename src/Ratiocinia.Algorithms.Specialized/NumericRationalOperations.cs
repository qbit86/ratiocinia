namespace Ratiocinia.Algorithms.Specialized
{
    using System;
    using System.Globalization;
    using System.Numerics;
    using Generic;
    using Models;

    /// <summary>
    /// Provides utility operations for rational numbers using generic numeric types.
    /// </summary>
    public static class NumericRationalOperations
    {
        /// <summary>
        /// Determines whether a rational number is in normalized form.
        /// </summary>
        /// <typeparam name="T">The numeric type of the numerator and denominator.</typeparam>
        /// <param name="numerator">The numerator of the rational number.</param>
        /// <param name="denominator">The denominator of the rational number.</param>
        /// <returns><see langword="true" /> if the rational number is normalized; otherwise, <see langword="false" />.</returns>
        public static bool IsNormalized<T>(T numerator, T denominator)
            where T : IAdditiveIdentity<T, T>, IComparable<T>, IEquatable<T>,
            IModulusOperators<T, T, T>, IMultiplicativeIdentity<T, T>, INumberBase<T>
        {
            var policy = Policy<T>.Instance;
            return RationalOperations.IsNormalized(
                numerator, denominator, T.AdditiveIdentity, T.MultiplicativeIdentity, policy);
        }

        /// <summary>
        /// Tries to format a rational number into a character span.
        /// </summary>
        /// <typeparam name="T">The numeric type of the numerator and denominator.</typeparam>
        /// <param name="numerator">The numerator of the rational number.</param>
        /// <param name="denominator">The denominator of the rational number.</param>
        /// <param name="destination">The span to write the formatted rational number to.</param>
        /// <param name="charsWritten">When this method returns, contains the number of characters written to the destination.</param>
        /// <param name="format">A span containing the format string.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <returns><see langword="true" /> if the formatting succeeded; otherwise, <see langword="false" />.</returns>
        public static bool TryFormat<T>(
            T numerator, T denominator, Span<char> destination, out int charsWritten,
            ReadOnlySpan<char> format, IFormatProvider? provider)
            where T : ISpanFormattable
        {
            charsWritten = 0;

            if (!numerator.TryFormat(destination, out int numeratorCharsWritten, format, provider))
                return false;

            int offset = numeratorCharsWritten;
            if (offset >= destination.Length)
                return false;

            destination[offset] = '/';
            offset++;

            if (!denominator.TryFormat(destination[offset..], out int denominatorCharsWritten, format, provider))
                return false;

            charsWritten = offset + denominatorCharsWritten;
            return true;
        }

        /// <summary>
        /// Tries to parse a string representation of a rational number into its numerator and denominator components.
        /// </summary>
        /// <typeparam name="T">The numeric type of the numerator and denominator.</typeparam>
        /// <param name="s">A span containing the characters to parse.</param>
        /// <param name="style">A bitwise combination of number styles that can be present in <paramref name="s" />.</param>
        /// <param name="provider">An object that supplies culture-specific formatting information.</param>
        /// <param name="numerator">When this method returns, contains the parsed numerator if parsing succeeded.</param>
        /// <param name="denominator">When this method returns, contains the parsed denominator if parsing succeeded.</param>
        /// <returns><see langword="true" /> if parsing succeeded; otherwise, <see langword="false" />.</returns>
        /// <remarks>
        /// The expected format is "numerator/denominator". If no separator is present, the input is parsed as a whole number
        /// with a denominator of 1. Parsing fails if the denominator is zero.
        /// </remarks>
        public static bool TryParse<T>(
            ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out T numerator, out T denominator)
            where T : INumberBase<T>
        {
            numerator = T.AdditiveIdentity;
            denominator = T.MultiplicativeIdentity;
            if (s.IsEmpty)
                return false;

            int slashIndex = s.IndexOf('/');
            if (slashIndex < 0)
            {
                if (!T.TryParse(s, style, provider, out var n))
                    return false;

                numerator = n;
                return true;
            }

            // Reject more than one separator
            if (s[(slashIndex + 1)..].IndexOf('/') >= 0)
                return false;

            var numeratorSpan = s[..slashIndex];
            var denominatorSpan = s[(slashIndex + 1)..];
            if (numeratorSpan.IsEmpty || denominatorSpan.IsEmpty)
                return false;

            if (!T.TryParse(numeratorSpan, style, provider, out var parsedNumerator) ||
                !T.TryParse(denominatorSpan, style, provider, out var parsedDenominator))
                return false;

            if (T.AdditiveIdentity.Equals(parsedDenominator))
                return false;

            numerator = parsedNumerator;
            denominator = parsedDenominator;
            return true;
        }
    }

    file sealed class Policy<T> : INumberBaseGreatestCommonDivisorFunctions<T>, INumberBaseAbsoluteFunctions<T>
        where T : IModulusOperators<T, T, T>, INumberBase<T>
    {
        internal static Policy<T> Instance { get; } = new();
    }
}
