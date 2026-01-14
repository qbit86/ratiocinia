namespace Ratiocinia
{
    using System.Numerics;

    partial struct BigIntegerRational
    {
        /// <summary>
        /// Gets the additive identity (zero) for <see cref="BigIntegerRational" />.
        /// </summary>
        /// <value>A rational number representing 0/1.</value>
        public static BigIntegerRational AdditiveIdentity { get; } =
            UnsafeCreate(BigInteger.Zero, BigInteger.One);
    }
}
