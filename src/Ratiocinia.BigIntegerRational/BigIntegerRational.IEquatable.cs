namespace Ratiocinia
{
    using System;

    partial struct BigIntegerRational
    {
        public bool Equals(BigIntegerRational other) =>
            Numerator.Equals(other.Numerator) && Denominator.Equals(other.Denominator);

        public override bool Equals(object? obj) => obj is BigIntegerRational other && Equals(other);

        public override int GetHashCode() => HashCode.Combine(Numerator, Denominator);

        public static bool operator ==(BigIntegerRational left, BigIntegerRational right) => left.Equals(right);

        public static bool operator !=(BigIntegerRational left, BigIntegerRational right) => !left.Equals(right);
    }
}
