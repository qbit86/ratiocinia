namespace Ratiocinia
{
    using System.Globalization;
    using System.Numerics;
    using Algorithms.Specialized;

    /// <summary>
    /// Provides factory methods for creating <see cref="Rational{T}" /> instances.
    /// </summary>
    public static class Rational
    {
        /// <summary>
        /// Attempts to create a <see cref="Rational{T}" /> from the specified numerator and denominator
        /// without normalization.
        /// </summary>
        /// <typeparam name="T">The underlying integer type for the numerator and denominator.</typeparam>
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
        public static bool TryCreate<T>(T numerator, T denominator, out Rational<T> rational)
            where T : IBinaryInteger<T> =>
            Rational<T>.TryCreate(numerator, denominator, out rational);

        /// <summary>
        /// Creates a <see cref="Rational{T}" /> from the specified numerator and denominator,
        /// normalizing the result.
        /// </summary>
        /// <typeparam name="T">The underlying integer type for the numerator and denominator.</typeparam>
        /// <param name="numerator">The numerator of the rational number.</param>
        /// <param name="denominator">The denominator of the rational number.</param>
        /// <returns>A normalized rational number equivalent to numerator/denominator.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown when <paramref name="denominator" /> is zero.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// Thrown when normalization causes an arithmetic overflow.
        /// </exception>
        public static Rational<T> Create<T>(T numerator, T denominator)
            where T : IBinaryInteger<T> =>
            Rational<T>.Create(numerator, denominator);

        /// <summary>
        /// Returns the absolute value of a rational number.
        /// </summary>
        /// <typeparam name="T">The underlying integer type for the numerator and denominator.</typeparam>
        /// <param name="value">The rational number to get the absolute value of.</param>
        /// <returns>The absolute value of <paramref name="value" />.</returns>
        public static Rational<T> Abs<T>(Rational<T> value) where T : IBinaryInteger<T> =>
            Rational<T>.Abs(value);

        /// <summary>
        /// Determines whether the specified rational number represents an integer value.
        /// </summary>
        /// <typeparam name="T">The underlying integer type for the numerator and denominator.</typeparam>
        /// <param name="value">The rational number to check.</param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="value" /> represents an integer (denominator is 1);
        /// otherwise, <see langword="false" />.
        /// </returns>
        public static bool IsInteger<T>(Rational<T> value) where T : IBinaryInteger<T> =>
            Rational<T>.IsInteger(value);

        /// <summary>
        /// Determines whether the specified rational number is negative.
        /// </summary>
        /// <typeparam name="T">The underlying integer type for the numerator and denominator.</typeparam>
        /// <param name="value">The rational number to check.</param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="value" /> is less than zero;
        /// otherwise, <see langword="false" />.
        /// </returns>
        public static bool IsNegative<T>(Rational<T> value) where T : IBinaryInteger<T> =>
            Rational<T>.IsNegative(value);

        /// <summary>
        /// Determines whether the specified rational number is positive.
        /// </summary>
        /// <typeparam name="T">The underlying integer type for the numerator and denominator.</typeparam>
        /// <param name="value">The rational number to check.</param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="value" /> is greater than zero;
        /// otherwise, <see langword="false" />.
        /// </returns>
        public static bool IsPositive<T>(Rational<T> value) where T : IBinaryInteger<T> =>
            Rational<T>.IsPositive(value);

        /// <summary>
        /// Determines whether the specified rational number is zero.
        /// </summary>
        /// <typeparam name="T">The underlying integer type for the numerator and denominator.</typeparam>
        /// <param name="value">The rational number to check.</param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="value" /> is equal to zero;
        /// otherwise, <see langword="false" />.
        /// </returns>
        public static bool IsZero<T>(Rational<T> value) where T : IBinaryInteger<T> =>
            Rational<T>.IsZero(value);
    }

    /// <summary>
    /// Represents an immutable rational number (fraction) with a numerator and denominator of type <typeparamref name="T" />.
    /// </summary>
    /// <typeparam name="T">The underlying integer type for the numerator and denominator.</typeparam>
    /// <remarks>
    /// <para>
    /// Rational numbers are always stored in normalized (reduced) form with a positive denominator.
    /// The default value represents zero (0/1).
    /// </para>
    /// <para>
    /// This type implements various numeric interfaces including <see cref="System.IEquatable{T}" />,
    /// <see cref="System.IComparable{T}" />, and arithmetic operators.
    /// </para>
    /// </remarks>
    public readonly partial struct Rational<T>
        where T : IBinaryInteger<T>
    {
        private Rational(T numerator, T denominator) => (Numerator, RawDenominator) = (numerator, denominator);

        /// <summary>
        /// Gets the numerator of the rational number.
        /// </summary>
        public T Numerator { get; }

        private T RawDenominator { get; }

        /// <summary>
        /// Gets the denominator of the rational number.
        /// </summary>
        /// <remarks>
        /// For a default-constructed rational, this returns one (the multiplicative identity).
        /// </remarks>
        public T Denominator => IsDefault ? T.One : RawDenominator;

        private bool IsDefault => T.AdditiveIdentity.CompareTo(RawDenominator) is 0;

        private static Rational<T> UnsafeCreate(T numerator, T denominator) => new(numerator, denominator);

        /// <summary>
        /// Attempts to create a <see cref="Rational{T}" /> from the specified numerator and denominator
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
        public static bool TryCreate(T numerator, T denominator, out Rational<T> rational)
        {
            bool result = NumericRationalOperations.IsNormalized(numerator, denominator);
            rational = result ? UnsafeCreate(numerator, denominator) : AdditiveIdentity;
            return result;
        }

        /// <summary>
        /// Creates a <see cref="Rational{T}" /> from the specified numerator and denominator,
        /// normalizing the result.
        /// </summary>
        /// <param name="numerator">The numerator of the rational number.</param>
        /// <param name="denominator">The denominator of the rational number.</param>
        /// <returns>A normalized rational number equivalent to numerator/denominator.</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// Thrown when <paramref name="denominator" /> is zero.
        /// </exception>
        /// <exception cref="System.OverflowException">
        /// Thrown when normalization causes an arithmetic overflow.
        /// </exception>
        public static Rational<T> Create(T numerator, T denominator)
        {
            var (normalizedNumerator, normalizedDenominator) =
                CheckedRationalOperations.Normalize(numerator, denominator);
            return UnsafeCreate(normalizedNumerator, normalizedDenominator);
        }

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
        public void Deconstruct(out T numerator, out T denominator)
        {
            numerator = Numerator;
            denominator = Denominator;
        }
    }
}
