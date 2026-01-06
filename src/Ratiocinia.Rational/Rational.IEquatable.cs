namespace Ratiocinia
{
    using System;

    partial struct Rational<T> : IEquatable<Rational<T>>
    {
        public bool Equals(Rational<T> other) =>
            Numerator.Equals(other.Numerator) && Denominator.Equals(other.Denominator);

        public override bool Equals(object? obj) => obj is Rational<T> other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);

        public static bool operator ==(Rational<T> left, Rational<T> right) => left.Equals(right);

        public static bool operator !=(Rational<T> left, Rational<T> right) => !left.Equals(right);
    }
}
