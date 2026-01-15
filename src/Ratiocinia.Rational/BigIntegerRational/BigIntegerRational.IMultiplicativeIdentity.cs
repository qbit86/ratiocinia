namespace Ratiocinia
{
    using System.Numerics;

    partial struct BigIntegerRational
    {
        /// <summary>
        /// Gets the multiplicative identity (one) for <see cref="BigIntegerRational" />.
        /// </summary>
        /// <value>A rational number representing 1/1.</value>
        public static BigIntegerRational MultiplicativeIdentity { get; } =
            UnsafeCreate(BigInteger.One, BigInteger.One);
    }
}
