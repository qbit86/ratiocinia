namespace Ratiocinia
{
    using System;
    using System.Diagnostics.CodeAnalysis;

    partial struct Rational<T> : ISpanParsable<Rational<T>>
    {
        public static Rational<T> Parse(string s, IFormatProvider? provider) =>
            Parse(s.AsSpan(), provider);

        public static bool TryParse([NotNullWhen(true)] string? s, IFormatProvider? provider, out Rational<T> result) =>
            TryParse(s.AsSpan(), provider, out result);

        public static Rational<T> Parse(ReadOnlySpan<char> s, IFormatProvider? provider) =>
            TryParse(s, provider, out var result)
                ? result
                : throw new FormatException("The input string was not in a correct format.");

        public static bool TryParse(ReadOnlySpan<char> s, IFormatProvider? provider, out Rational<T> result) =>
            TryParseCore(s, provider, out result);

        private static bool TryParseCore(ReadOnlySpan<char> s, IFormatProvider? provider, out Rational<T> result)
        {
            s = s.Trim();
            if (s.IsEmpty)
                return None(out result);

            int slashIndex = s.IndexOf('/');
            if (slashIndex < 0)
            {
                if (!T.TryParse(s, provider, out var numerator))
                    return None(out result);

                result = Create(numerator, T.MultiplicativeIdentity);
                return true;
            }

            // Reject more than one separator
            if (s[(slashIndex + 1)..].IndexOf('/') >= 0)
                return None(out result);

            var numeratorSpan = s[..slashIndex].Trim();
            var denominatorSpan = s[(slashIndex + 1)..].Trim();
            if (numeratorSpan.IsEmpty || denominatorSpan.IsEmpty)
                return None(out result);

            if (!T.TryParse(numeratorSpan, provider, out var parsedNumerator) ||
                !T.TryParse(denominatorSpan, provider, out var parsedDenominator))
                return None(out result);

            if (parsedDenominator.Equals(T.AdditiveIdentity))
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

            static bool None(out Rational<T> r)
            {
                r = AdditiveIdentity;
                return false;
            }
        }
    }
}
