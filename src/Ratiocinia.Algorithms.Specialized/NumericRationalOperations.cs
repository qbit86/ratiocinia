namespace Ratiocinia.Algorithms.Specialized
{
    using System;
    using System.Globalization;
    using System.Numerics;
    using Generic;
    using Models;

    public static class NumericRationalOperations
    {
        public static bool IsNormalized<T>(T numerator, T denominator)
            where T : IAdditiveIdentity<T, T>, IComparable<T>, IEquatable<T>,
            IModulusOperators<T, T, T>, IMultiplicativeIdentity<T, T>, INumberBase<T>
        {
            var policy = Policy<T>.Instance;
            return RationalOperations.IsNormalized(
                numerator, denominator, T.AdditiveIdentity, T.MultiplicativeIdentity, policy);
        }

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

        public static bool TryParse<T>(
            ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out T numerator, out T denominator)
            where T : INumberBase<T>
        {
            numerator = T.AdditiveIdentity;
            denominator = T.MultiplicativeIdentity;
            s = s.Trim();
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

            var numeratorSpan = s[..slashIndex].Trim();
            var denominatorSpan = s[(slashIndex + 1)..].Trim();
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
