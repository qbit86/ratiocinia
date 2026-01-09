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
        public static BigIntegerRational Abs(BigIntegerRational value) =>
            BigInteger.IsNegative(value.Numerator) ? -value : value;

        public static bool IsEvenInteger(BigIntegerRational value) =>
            IsInteger(value) && BigInteger.IsEvenInteger(value.Numerator);

        public static bool IsInteger(BigIntegerRational value) => BigInteger.One.Equals(value.Denominator);

        public static bool IsNegative(BigIntegerRational value) => BigInteger.IsNegative(value.Numerator);

        public static bool IsNormal(BigIntegerRational value) => !value.Numerator.IsZero;

        public static bool IsOddInteger(BigIntegerRational value) =>
            IsInteger(value) && BigInteger.IsOddInteger(value.Numerator);

        public static bool IsPositive(BigIntegerRational value) =>
            !value.Numerator.IsZero && !BigInteger.IsNegative(value.Numerator);

        public static bool IsZero(BigIntegerRational value) => value.Numerator.IsZero;

        public static BigIntegerRational MaxMagnitude(BigIntegerRational x, BigIntegerRational y) =>
            CompareMagnitude(x, y) >= 0 ? x : y;

        public static BigIntegerRational MaxMagnitudeNumber(BigIntegerRational x, BigIntegerRational y) =>
            MaxMagnitude(x, y);

        public static BigIntegerRational MinMagnitude(BigIntegerRational x, BigIntegerRational y) =>
            CompareMagnitude(x, y) <= 0 ? x : y;

        public static BigIntegerRational MinMagnitudeNumber(BigIntegerRational x, BigIntegerRational y) =>
            MinMagnitude(x, y);

        public static BigIntegerRational Parse(string s, NumberStyles style, IFormatProvider? provider) =>
            Parse(s.AsSpan(), style, provider);

        public static BigIntegerRational Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider) =>
            TryParse(s, style, provider, out var result)
                ? result
                : throw new FormatException("The input string was not in a correct format.");

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

        public static bool TryConvertToChecked<TOther>(
            BigIntegerRational value, [MaybeNullWhen(false)] out TOther result)
            where TOther : INumberBase<TOther>
        {
            // Checked conversion requires an integral value.
            if (!value.Denominator.Equals(BigInteger.One) &&
                !(value.Numerator % value.Denominator).IsZero)
                return None(out result);

            var quotient = value.Numerator / value.Denominator;
            return TOther.TryConvertFromChecked(quotient, out result);
        }

        public static bool TryConvertToSaturating<TOther>(
            BigIntegerRational value, [MaybeNullWhen(false)] out TOther result)
            where TOther : INumberBase<TOther>
        {
            var quotient = value.Numerator / value.Denominator;
            return TOther.TryConvertFromSaturating(quotient, out result);
        }

        public static bool TryConvertToTruncating<TOther>(
            BigIntegerRational value, [MaybeNullWhen(false)] out TOther result)
            where TOther : INumberBase<TOther>
        {
            var quotient = value.Numerator / value.Denominator;
            return TOther.TryConvertFromTruncating(quotient, out result);
        }

        public static bool TryParse(
            ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out BigIntegerRational result) =>
            TryParseCore(s, style, provider, out result);

        public static bool TryParse(
            [NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider,
            out BigIntegerRational result) =>
            TryParse(s.AsSpan(), style, provider, out result);

        public static BigIntegerRational One => MultiplicativeIdentity;

        public static int Radix => 10;

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
