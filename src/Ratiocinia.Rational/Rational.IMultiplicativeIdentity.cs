namespace Ratiocinia
{
    partial struct Rational<T>
    {
        /// <summary>
        /// Gets the multiplicative identity (one) for <see cref="Rational{T}" />.
        /// </summary>
        /// <value>A rational number representing 1/1.</value>
        public static Rational<T> MultiplicativeIdentity { get; } =
            UnsafeCreate(T.MultiplicativeIdentity, T.MultiplicativeIdentity);
    }
}
