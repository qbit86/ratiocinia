namespace Ratiocinia
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Numerics;
    using Algorithms.Specialized;

    partial struct Rational<T> : INumberBase<Rational<T>>
    {
        public static Rational<T> Abs(Rational<T> value) => T.IsNegative(value.Numerator) ? -value : value;

        public static bool IsCanonical(Rational<T> value) => true;

        public static bool IsComplexNumber(Rational<T> value) => false;

        public static bool IsEvenInteger(Rational<T> value) =>
            IsInteger(value) && T.IsEvenInteger(value.Numerator);

        public static bool IsFinite(Rational<T> value) => true;

        public static bool IsImaginaryNumber(Rational<T> value) => false;

        public static bool IsInfinity(Rational<T> value) => false;

        public static bool IsInteger(Rational<T> value) => T.MultiplicativeIdentity.Equals(value.Denominator);

        public static bool IsNaN(Rational<T> value) => false;

        public static bool IsNegative(Rational<T> value) => T.IsNegative(value.Numerator);

        public static bool IsNegativeInfinity(Rational<T> value) => false;

        public static bool IsNormal(Rational<T> value) => !T.IsZero(value.Numerator);

        public static bool IsOddInteger(Rational<T> value) =>
            IsInteger(value) && T.IsOddInteger(value.Numerator);

        public static bool IsPositive(Rational<T> value) =>
            !T.IsZero(value.Numerator) && !T.IsNegative(value.Numerator);

        public static bool IsPositiveInfinity(Rational<T> value) => false;

        public static bool IsRealNumber(Rational<T> value) => true;

        public static bool IsSubnormal(Rational<T> value) => false;

        public static bool IsZero(Rational<T> value) => T.IsZero(value.Numerator);

        public static Rational<T> MaxMagnitude(Rational<T> x, Rational<T> y) => CompareMagnitude(x, y) >= 0 ? x : y;

        public static Rational<T> MaxMagnitudeNumber(Rational<T> x, Rational<T> y) => MaxMagnitude(x, y);

        public static Rational<T> MinMagnitude(Rational<T> x, Rational<T> y) =>
            CompareMagnitude(x, y) <= 0 ? x : y;

        public static Rational<T> MinMagnitudeNumber(Rational<T> x, Rational<T> y) => MinMagnitude(x, y);

        public static Rational<T> Parse(string s, NumberStyles style, IFormatProvider? provider) =>
            Parse(s.AsSpan(), style, provider);

        public static Rational<T> Parse(ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider) =>
            TryParse(s, style, provider, out var result)
                ? result
                : throw new FormatException("The input string was not in a correct format.");

        public static bool TryConvertFromChecked<TOther>(TOther value, out Rational<T> result)
            where TOther : INumberBase<TOther>
        {
            if (!T.TryConvertFromChecked(value, out var converted))
                return None(out result);

            result = UnsafeCreate(converted, T.MultiplicativeIdentity);
            return true;
        }

        public static bool TryConvertFromSaturating<TOther>(TOther value, out Rational<T> result)
            where TOther : INumberBase<TOther>
        {
            if (!T.TryConvertFromSaturating(value, out var converted))
                return None(out result);

            result = UnsafeCreate(converted, T.MultiplicativeIdentity);
            return true;
        }

        public static bool TryConvertFromTruncating<TOther>(TOther value, out Rational<T> result)
            where TOther : INumberBase<TOther>
        {
            if (!T.TryConvertFromTruncating(value, out var converted))
                return None(out result);

            result = UnsafeCreate(converted, T.MultiplicativeIdentity);
            return true;
        }

        public static bool TryConvertToChecked<TOther>(Rational<T> value, [MaybeNullWhen(false)] out TOther result)
            where TOther : INumberBase<TOther>
        {
            // Checked conversion requires an integral value.
            if (!value.Denominator.Equals(T.MultiplicativeIdentity) &&
                !T.IsZero(value.Numerator % value.Denominator))
                return None(out result);

            var quotient = value.Numerator / value.Denominator;
            return TOther.TryConvertFromChecked(quotient, out result);
        }

        public static bool TryConvertToSaturating<TOther>(Rational<T> value, [MaybeNullWhen(false)] out TOther result)
            where TOther : INumberBase<TOther>
        {
            var quotient = value.Numerator / value.Denominator;
            return TOther.TryConvertFromSaturating(quotient, out result);
        }

        public static bool TryConvertToTruncating<TOther>(Rational<T> value, [MaybeNullWhen(false)] out TOther result)
            where TOther : INumberBase<TOther>
        {
            var quotient = value.Numerator / value.Denominator;
            return TOther.TryConvertFromTruncating(quotient, out result);
        }

        public static bool TryParse(
            ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out Rational<T> result) =>
            TryParseCore(s, style, provider, out result);

        public static bool TryParse(
            [NotNullWhen(true)] string? s, NumberStyles style, IFormatProvider? provider,
            out Rational<T> result) =>
            TryParse(s.AsSpan(), style, provider, out result);

        public static Rational<T> One => MultiplicativeIdentity;

        public static int Radix => T.Radix;

        public static Rational<T> Zero => AdditiveIdentity;

        private static int CompareMagnitude(Rational<T> x, Rational<T> y) => Abs(x).CompareTo(Abs(y));

        private static bool TryParseCore(
            ReadOnlySpan<char> s, NumberStyles style, IFormatProvider? provider, out Rational<T> result)
        {
            if (!NumericRationalOperations.TryParse<T>(
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
            catch (OverflowException)
            {
                return None(out result);
            }
        }

        private static bool None(out Rational<T> result)
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
