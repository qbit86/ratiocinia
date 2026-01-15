namespace Ratiocinia
{
    using System.Globalization;
    using System.Numerics;
    using Algorithms.Specialized;

    /// <summary>
    /// Represents an immutable rational number (fraction) with a <see cref="BigInteger" /> numerator and denominator.
    /// </summary>
    /// <remarks>
    /// <para>
    /// Rational numbers are always stored in normalized (reduced) form with a positive denominator.
    /// The default value represents zero (0/1).
    /// </para>
    /// <para>
    /// Unlike the generic <c>Rational&lt;T&gt;</c> type, this type uses <see cref="BigInteger" /> for arbitrary precision,
    /// meaning arithmetic operations will not overflow.
    /// </para>
    /// <para>
    /// This type implements various numeric interfaces including <see cref="System.IEquatable{T}" />,
    /// <see cref="System.IComparable{T}" />, and arithmetic operators.
    /// </para>
    /// </remarks>
    public readonly partial struct BigIntegerRational
    {
        private BigIntegerRational(BigInteger numerator, BigInteger denominator) =>
            (Numerator, RawDenominator) = (numerator, denominator);

        /// <summary>
        /// Gets the numerator of the rational number.
        /// </summary>
        public BigInteger Numerator { get; }

        private BigInteger RawDenominator { get; }

        /// <summary>
        /// Gets the denominator of the rational number.
        /// </summary>
        /// <remarks>
        /// For a default-constructed rational, this returns one.
        /// </remarks>
        public BigInteger Denominator => IsDefault ? BigInteger.One : RawDenominator;

        private bool IsDefault => RawDenominator.IsZero;

        private static BigIntegerRational UnsafeCreate(BigInteger numerator, BigInteger denominator) =>
            new(numerator, denominator);

        /// <summary>
        /// Attempts to create a <see cref="BigIntegerRational" /> from the specified numerator and denominator
        /// without normalization.
        /// </summary>
        /// <param name="numerator">The numerator of the rational number.</param>
        /// <param name="denominator">The denominator of the rational number.</param>
        /// <param name="rational">
        /// When this method returns, contains the created rational number if the inputs were already normalized;
        /// otherwise, the additive identity (zero).
        /// </param>
        /// <returns>
        /// <see langword="true" /> if the rational number was created successfully (inputs were normalized);
        /// otherwise, <see langword="false" />.
        /// </returns>
        public static bool TryCreate(BigInteger numerator, BigInteger denominator, out BigIntegerRational rational)
        {
            bool result = BigIntegerRationalOperations.IsNormalized(numerator, denominator);
            rational = result ? UnsafeCreate(numerator, denominator) : AdditiveIdentity;
            return result;
        }

        /// <summary>
        /// Creates a <see cref="BigIntegerRational" /> from the specified numerator and denominator,
        /// normalizing the result.
        /// </summary>
        /// <param name="numerator">The numerator of the rational number.</param>
        /// <param name="denominator">The denominator of the rational number.</param>
        /// <returns>A normalized rational number equivalent to numerator/denominator.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown when <paramref name="denominator" /> is zero.
        /// </exception>
        public static BigIntegerRational Create(BigInteger numerator, BigInteger denominator)
        {
            var (normalizedNumerator, normalizedDenominator) =
                BigIntegerRationalOperations.Normalize(numerator, denominator);
            return UnsafeCreate(normalizedNumerator, normalizedDenominator);
        }

        /// <summary>
        /// Creates a <see cref="BigIntegerRational" /> from the specified integer value.
        /// </summary>
        /// <param name="numerator">The integer value to convert to a rational number.</param>
        /// <returns>A rational number equivalent to numerator/1.</returns>
        public static BigIntegerRational Create(BigInteger numerator) => UnsafeCreate(numerator, BigInteger.One);

        /// <summary>
        /// Returns a string representation of the rational number using the invariant culture.
        /// </summary>
        /// <returns>A string in the format "numerator/denominator".</returns>
        public override string ToString() => ToString(string.Empty, CultureInfo.InvariantCulture);

        /// <summary>
        /// Deconstructs the rational number into its numerator and denominator.
        /// </summary>
        /// <param name="numerator">When this method returns, contains the numerator.</param>
        /// <param name="denominator">When this method returns, contains the denominator.</param>
        public void Deconstruct(out BigInteger numerator, out BigInteger denominator)
        {
            numerator = Numerator;
            denominator = Denominator;
        }
    }
}
