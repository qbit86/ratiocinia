namespace Ratiocinia
{
    using System;

    partial struct Rational<T>
    {
        /// <summary>
        /// Determines whether this rational number equals another rational number.
        /// </summary>
        /// <param name="other">The rational number to compare with.</param>
        /// <returns>
        /// <see langword="true" /> if the two rational numbers are equal; otherwise, <see langword="false" />.
        /// </returns>
        public bool Equals(Rational<T> other) =>
            Numerator.Equals(other.Numerator) && Denominator.Equals(other.Denominator);

        /// <summary>
        /// Determines whether this rational number equals another object.
        /// </summary>
        /// <param name="obj">The object to compare with.</param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="obj" /> is a <see cref="Rational{T}" />
        /// and equals this instance; otherwise, <see langword="false" />.
        /// </returns>
        public override bool Equals(object? obj) => obj is Rational<T> other && Equals(other);

        /// <summary>
        /// Returns the hash code for this rational number.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);

        /// <summary>
        /// Determines whether two rational numbers are equal.
        /// </summary>
        /// <param name="left">The first rational number to compare.</param>
        /// <param name="right">The second rational number to compare.</param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="left" /> equals <paramref name="right" />;
        /// otherwise, <see langword="false" />.
        /// </returns>
        public static bool operator ==(Rational<T> left, Rational<T> right) => left.Equals(right);

        /// <summary>
        /// Determines whether two rational numbers are not equal.
        /// </summary>
        /// <param name="left">The first rational number to compare.</param>
        /// <param name="right">The second rational number to compare.</param>
        /// <returns>
        /// <see langword="true" /> if <paramref name="left" /> does not equal <paramref name="right" />;
        /// otherwise, <see langword="false" />.
        /// </returns>
        public static bool operator !=(Rational<T> left, Rational<T> right) => !left.Equals(right);
    }
}
