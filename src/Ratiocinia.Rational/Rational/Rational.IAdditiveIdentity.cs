namespace Ratiocinia
{
    partial struct Rational<T>
    {
        /// <summary>
        /// Gets the additive identity (zero) for <see cref="Rational{T}" />.
        /// </summary>
        /// <value>A rational number representing 0/1.</value>
        public static Rational<T> AdditiveIdentity { get; } =
            UnsafeCreate(T.AdditiveIdentity, T.MultiplicativeIdentity);
    }
}
