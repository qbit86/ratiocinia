namespace Ratiocinia
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Numerics;
    using Algorithms.Specialized;
    using Models;

    partial struct BigIntegerRational : IPartialNumberBase<BigIntegerRational>
    {
        /// <summary>
        /// Computes the absolute value of a rational number.
        /// </summary>
        /// <param name="value">The rational number for which to compute the absolute value.</param>
        /// <returns>The absolute value of <paramref name="value" />.</returns>
        public static BigIntegerRational Abs(BigIntegerRational value) =>
            BigInteger.IsNegative(value.Numerator) ? -value : value;

        /// <summary>
        /// Determines whether the specified rational number represents an even integer.
        /// </summary>
        /// <param name="value">The rational number to check.</param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="value" /> is an even integer; otherwise, <see langword="false" />.
        /// </returns>
        public static bool IsEvenInteger(BigIntegerRational value) =>
            IsInteger(value) && BigInteger.IsEvenInteger(value.Numerator);

        /// <summary>
        /// Determines whether the specified rational number represents an integer.
        /// </summary>
        /// <param name="value">The rational number to check.</param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="value" /> has a denominator of one; otherwise, <see langword="false" />.
        /// </returns>
        public static bool IsInteger(BigIntegerRational value) => BigInteger.One.Equals(value.Denominator);

        /// <summary>
        /// Determines whether the specified rational number is negative.
        /// </summary>
        /// <param name="value">The rational number to check.</param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="value" /> is negative; otherwise, <see langword="false" />.
        /// </returns>
        public static bool IsNegative(BigIntegerRational value) => BigInteger.IsNegative(value.Numerator);

        /// <summary>
        /// Determines whether the specified rational number is normal (non-zero).
        /// </summary>
        /// <param name="value">The rational number to check.</param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="value" /> is not zero; otherwise, <see langword="false" />.
        /// </returns>
        public static bool IsNormal(BigIntegerRational value) => !value.Numerator.IsZero;

        /// <summary>
        /// Determines whether the specified rational number represents an odd integer.
        /// </summary>
        /// <param name="value">The rational number to check.</param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="value" /> is an odd integer; otherwise, <see langword="false" />.
        /// </returns>
        public static bool IsOddInteger(BigIntegerRational value) =>
            IsInteger(value) && BigInteger.IsOddInteger(value.Numerator);

        /// <summary>
        /// Determines whether the specified rational number is positive.
        /// </summary>
        /// <param name="value">The rational number to check.</param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="value" /> is greater than zero; otherwise, <see langword="false" />.
        /// </returns>
        public static bool IsPositive(BigIntegerRational value) =>
            !value.Numerator.IsZero && !BigInteger.IsNegative(value.Numerator);

        /// <summary>
        /// Determines whether the specified rational number is zero.
        /// </summary>
        /// <param name="value">The rational number to check.</param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="value" /> is zero; otherwise, <see langword="false" />.
        /// </returns>
        public static bool IsZero(BigIntegerRational value) => value.Numerator.IsZero;

        /// <summary>
        /// Returns the larger magnitude of two rational numbers.
        /// </summary>
        /// <param name="x">The first rational number to compare.</param>
        /// <param name="y">The second rational number to compare.</param>
        /// <returns>
        /// <paramref name="x" /> if its absolute value is greater than or equal to the absolute value of <paramref name="y" />;
        /// otherwise, <paramref name="y" />.
        /// </returns>
        public static BigIntegerRational MaxMagnitude(BigIntegerRational x, BigIntegerRational y) =>
            CompareMagnitude(x, y) >= 0 ? x : y;

        /// <summary>
        /// Returns the larger magnitude of two rational numbers.
        /// </summary>
        /// <param name="x">The first rational number to compare.</param>
        /// <param name="y">The second rational number to compare.</param>
        /// <returns>
        /// <paramref name="x" /> if its absolute value is greater than or equal to the absolute value of <paramref name="y" />;
        /// otherwise, <paramref name="y" />.
        /// </returns>
        /// <remarks>
        /// Since <see cref="BigIntegerRational" /> does not support NaN values, this method behaves identically to
        /// <see cref="MaxMagnitude" />.
        /// </remarks>
        public static BigIntegerRational MaxMagnitudeNumber(BigIntegerRational x, BigIntegerRational y) =>
            MaxMagnitude(x, y);

        /// <summary>
        /// Returns the smaller magnitude of two rational numbers.
        /// </summary>
        /// <param name="x">The first rational number to compare.</param>
        /// <param name="y">The second rational number to compare.</param>
        /// <returns>
        /// <paramref name="x" /> if its absolute value is less than or equal to the absolute value of <paramref name="y" />;
        /// otherwise, <paramref name="y" />.
        /// </returns>
        public static BigIntegerRational MinMagnitude(BigIntegerRational x, BigIntegerRational y) =>
            CompareMagnitude(x, y) <= 0 ? x : y;

        /// <summary>
        /// Returns the smaller magnitude of two rational numbers.
        /// </summary>
        /// <param name="x">The first rational number to compare.</param>
        /// <param name="y">The second rational number to compare.</param>
        /// <returns>
        /// <paramref name="x" /> if its absolute value is less than or equal to the absolute value of <paramref name="y" />;
        /// otherwise, <paramref name="y" />.
        /// </returns>
        /// <remarks>
        /// Since <see cref="BigIntegerRational" /> does not support NaN values, this method behaves identically to
        /// <see cref="MinMagnitude" />.
        /// </remarks>
        public static BigIntegerRational MinMagnitudeNumber(BigIntegerRational x, BigIntegerRational y) =>
            MinMagnitude(x, y);

        /// <summary>
        /// Parses a string into a rational number.
        /// </summary>
        /// <param name="s">The string to parse.</param>
        /// <param name="style">A bitwise combination of number styles that can be present in <paramref name="s" />.</param>
        /// <param name="provider">An object that provides culture-specific formatting information.</param>
        /// <returns>The parsed rational number.</returns>
        /// <exception cref="FormatException">Thrown when <paramref name="s" /> is not in a valid format.</exception>
        public static BigIntegerRational Parse(string s, NumberStyles style, IFormatProvider? provider) =>
            Parse(s.AsSpan(), style, provider);

        /// <summary>
        /// Parses a character span into a rational number.
        /// </summary>
        /// <param name="s">The character span to parse.</param>
        /// <param name="style">A bitwise combination of number styles that can be present in <paramref name="s" />.</param>
        /// <param name="provider">An object that provides culture-specific formatting information.</param>
        /// <returns>The parsed rational number.</returns>
        /// <exception cref="FormatException">Thrown when <paramref name="s" /> is not in a valid format.</exception>
        public static BigIntegerRational Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider) =>
            TryParse(s, style, provider, out var result)
                ? result
                : throw new FormatException("The input string was not in a correct format.");

        /// <summary>
        /// Attempts to convert a value to a <see cref="BigIntegerRational" /> using checked arithmetic.
        /// </summary>
        /// <typeparam name="TOther">The type of the value to convert.</typeparam>
        /// <param name="value">The value to convert.</param>
        /// <param name="result">
        /// When this method returns, contains the converted rational number if the conversion succeeded;
        /// otherwise, the additive identity.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the conversion succeeded; otherwise, <see langword="false" />.
        /// </returns>
        public static bool TryConvertFromChecked<TOther>(TOther value, out BigIntegerRational result)
            where TOther : INumberBase<TOther>
        {
            if (!TryConvertFrom(value, out BigInteger converted))
                return None(out result);

            result = UnsafeCreate(converted, BigInteger.One);
            return true;

            static bool TryConvertFrom<TSelf>(TOther value, [MaybeNullWhen(false)] out TSelf result)
                where TSelf : INumberBase<TSelf> =>
                TSelf.TryConvertFromChecked(value, out result);
        }

        /// <summary>
        /// Attempts to convert a value to a <see cref="BigIntegerRational" /> using saturating arithmetic.
        /// </summary>
        /// <typeparam name="TOther">The type of the value to convert.</typeparam>
        /// <param name="value">The value to convert.</param>
        /// <param name="result">
        /// When this method returns, contains the converted rational number if the conversion succeeded;
        /// otherwise, the additive identity.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the conversion succeeded; otherwise, <see langword="false" />.
        /// </returns>
        public static bool TryConvertFromSaturating<TOther>(TOther value, out BigIntegerRational result)
            where TOther : INumberBase<TOther>
        {
            if (!TryConvertFrom(value, out BigInteger converted))
                return None(out result);

            result = UnsafeCreate(converted, BigInteger.One);
            return true;

            static bool TryConvertFrom<TSelf>(TOther value, [MaybeNullWhen(false)] out TSelf result)
                where TSelf : INumberBase<TSelf> =>
                TSelf.TryConvertFromSaturating(value, out result);
        }

        /// <summary>
        /// Attempts to convert a value to a <see cref="BigIntegerRational" /> using truncating arithmetic.
        /// </summary>
        /// <typeparam name="TOther">The type of the value to convert.</typeparam>
        /// <param name="value">The value to convert.</param>
        /// <param name="result">
        /// When this method returns, contains the converted rational number if the conversion succeeded;
        /// otherwise, the additive identity.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the conversion succeeded; otherwise, <see langword="false" />.
        /// </returns>
        public static bool TryConvertFromTruncating<TOther>(TOther value, out BigIntegerRational result)
            where TOther : INumberBase<TOther>
        {
            if (!TryConvertFrom(value, out BigInteger converted))
                return None(out result);

            result = UnsafeCreate(converted, BigInteger.One);
            return true;

            static bool TryConvertFrom<TSelf>(TOther value, [MaybeNullWhen(false)] out TSelf result)
                where TSelf : INumberBase<TSelf> =>
                TSelf.TryConvertFromTruncating(value, out result);
        }

        /// <summary>
        /// Attempts to convert a <see cref="BigIntegerRational" /> to another type using checked arithmetic.
        /// </summary>
        /// <typeparam name="TOther">The type to convert to.</typeparam>
        /// <param name="value">The rational number to convert.</param>
        /// <param name="result">
        /// When this method returns, contains the converted value if the conversion succeeded;
        /// otherwise, the default value.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the conversion succeeded; otherwise, <see langword="false" />.
        /// </returns>
        /// <remarks>
        /// This method requires the rational number to represent an integer value (denominator divides numerator evenly).
        /// </remarks>
        public static bool TryConvertToChecked<TOther>(
            BigIntegerRational value, [MaybeNullWhen(false)] out TOther result)
            where TOther : INumberBase<TOther>
        {
            // Checked conversion requires an integral value.
            // Since the rational is normalized, denominator != 1 means it's not an integer.
            if (!IsInteger(value))
                return None(out result);

            return TOther.TryConvertFromChecked(value.Numerator, out result);
        }

        /// <summary>
        /// Attempts to convert a <see cref="BigIntegerRational" /> to another type using saturating arithmetic.
        /// </summary>
        /// <typeparam name="TOther">The type to convert to.</typeparam>
        /// <param name="value">The rational number to convert.</param>
        /// <param name="result">
        /// When this method returns, contains the converted value if the conversion succeeded;
        /// otherwise, the default value.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the conversion succeeded; otherwise, <see langword="false" />.
        /// </returns>
        /// <remarks>
        /// This method truncates the rational number to an integer by dividing the numerator by the denominator.
        /// </remarks>
        public static bool TryConvertToSaturating<TOther>(
            BigIntegerRational value, [MaybeNullWhen(false)] out TOther result)
            where TOther : INumberBase<TOther>
        {
            var quotient = value.Numerator / value.Denominator;
            return TOther.TryConvertFromSaturating(quotient, out result);
        }

        /// <summary>
        /// Attempts to convert a <see cref="BigIntegerRational" /> to another type using truncating arithmetic.
        /// </summary>
        /// <typeparam name="TOther">The type to convert to.</typeparam>
        /// <param name="value">The rational number to convert.</param>
        /// <param name="result">
        /// When this method returns, contains the converted value if the conversion succeeded;
        /// otherwise, the default value.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the conversion succeeded; otherwise, <see langword="false" />.
        /// </returns>
        /// <remarks>
        /// This method truncates the rational number to an integer by dividing the numerator by the denominator.
        /// </remarks>
        public static bool TryConvertToTruncating<TOther>(
            BigIntegerRational value, [MaybeNullWhen(false)] out TOther result)
            where TOther : INumberBase<TOther>
        {
            var quotient = value.Numerator / value.Denominator;
            return TOther.TryConvertFromTruncating(quotient, out result);
        }

        /// <summary>
        /// Attempts to parse a character span into a rational number.
        /// </summary>
        /// <param name="s">The character span to parse.</param>
        /// <param name="style">A bitwise combination of number styles that can be present in <paramref name="s" />.</param>
        /// <param name="provider">An object that provides culture-specific formatting information.</param>
        /// <param name="result">
        /// When this method returns, contains the parsed rational number if parsing succeeded;
        /// otherwise, the additive identity.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="s" /> was parsed successfully; otherwise, <see langword="false" />.
        /// </returns>
        public static bool TryParse(
            ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out BigIntegerRational result) =>
            TryParseCore(s, style, provider, out result);

        /// <summary>
        /// Attempts to parse a string into a rational number.
        /// </summary>
        /// <param name="s">The string to parse.</param>
        /// <param name="style">A bitwise combination of number styles that can be present in <paramref name="s" />.</param>
        /// <param name="provider">An object that provides culture-specific formatting information.</param>
        /// <param name="result">
        /// When this method returns, contains the parsed rational number if parsing succeeded;
        /// otherwise, the additive identity.
        /// </param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="s" /> was parsed successfully; otherwise, <see langword="false" />.
        /// </returns>
        public static bool TryParse(
            [NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider,
            out BigIntegerRational result) =>
            TryParse(s.AsSpan(), style, provider, out result);

        /// <summary>
        /// Gets the value one (1/1).
        /// </summary>
        public static BigIntegerRational One => MultiplicativeIdentity;

        /// <summary>
        /// Gets the radix (base) used by <see cref="BigInteger" />, which is 10.
        /// </summary>
        public static int Radix => 10;

        /// <summary>
        /// Gets the value zero (0/1).
        /// </summary>
        public static BigIntegerRational Zero => AdditiveIdentity;

        private static int CompareMagnitude(BigIntegerRational x, BigIntegerRational y) => Abs(x).CompareTo(Abs(y));

        private static bool TryParseCore(
            ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out BigIntegerRational result)
        {
            if (!NumericRationalOperations.TryParse<BigInteger>(
                    s, style, provider, out var parsedNumerator, out var parsedDenominator))
                return None(out result);

            try
            {
                result = Create(parsedNumerator, parsedDenominator);
                return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                return None(out result);
            }
        }

        private static bool None(out BigIntegerRational result)
        {
            result = AdditiveIdentity;
            return false;
        }

        private static bool None<TOther>([MaybeNullWhen(false)] out TOther result)
        {
            result = default!;
            return false;
        }
    }
}
