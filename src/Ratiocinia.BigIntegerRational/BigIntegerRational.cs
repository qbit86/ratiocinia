namespace Ratiocinia
{
    using System.Globalization;
    using System.Numerics;
    using Algorithms.Specialized;

    public readonly partial struct BigIntegerRational
    {
        private BigIntegerRational(BigInteger numerator, BigInteger denominator) =>
            (Numerator, RawDenominator) = (numerator, denominator);

        public BigInteger Numerator { get; }

        private BigInteger RawDenominator { get; }

        public BigInteger Denominator => IsDefault ? BigInteger.One : RawDenominator;

        private bool IsDefault => RawDenominator.IsZero;

        private static BigIntegerRational UnsafeCreate(BigInteger numerator, BigInteger denominator) =>
            new(numerator, denominator);

        public static bool TryCreate(BigInteger numerator, BigInteger denominator, out BigIntegerRational rational)
        {
            bool result = BigIntegerRationalOperations.IsNormalized(numerator, denominator);
            rational = result ? UnsafeCreate(numerator, denominator) : AdditiveIdentity;
            return result;
        }

        public static BigIntegerRational Create(BigInteger numerator, BigInteger denominator)
        {
            var (normalizedNumerator, normalizedDenominator) =
                BigIntegerRationalOperations.Normalize(numerator, denominator);
            return UnsafeCreate(normalizedNumerator, normalizedDenominator);
        }

        public override string ToString() => ToString(string.Empty, CultureInfo.InvariantCulture);

        public void Deconstruct(out BigInteger numerator, out BigInteger denominator)
        {
            numerator = Numerator;
            denominator = Denominator;
        }
    }
}
