namespace Ratiocinia.Models
{
    using System.Numerics;

    /// <summary>
    /// Provides default implementations for <see cref="INumberBase{TSelf}" /> classification methods
    /// suitable for finite real number types (such as rational numbers).
    /// </summary>
    /// <remarks>
    /// This interface provides sensible defaults for types that represent finite, real numbers:
    /// values are always canonical, finite, and real; never complex, imaginary, infinite, NaN, or subnormal.
    /// </remarks>
    /// <typeparam name="T">The numeric type that implements <see cref="INumberBase{TSelf}" />.</typeparam>
    public interface IPartialNumberBase<T> : INumberBase<T> where T : INumberBase<T>
    {
        /// <inheritdoc />
        static bool INumberBase<T>.IsCanonical(T value) => true;

        /// <inheritdoc />
        static bool INumberBase<T>.IsComplexNumber(T value) => false;

        /// <inheritdoc />
        static bool INumberBase<T>.IsFinite(T value) => true;

        /// <inheritdoc />
        static bool INumberBase<T>.IsImaginaryNumber(T value) => false;

        /// <inheritdoc />
        static bool INumberBase<T>.IsInfinity(T value) => false;

        /// <inheritdoc />
        static bool INumberBase<T>.IsNaN(T value) => false;

        /// <inheritdoc />
        static bool INumberBase<T>.IsNegativeInfinity(T value) => false;

        /// <inheritdoc />
        static bool INumberBase<T>.IsPositiveInfinity(T value) => false;

        /// <inheritdoc />
        static bool INumberBase<T>.IsRealNumber(T value) => true;

        /// <inheritdoc />
        static bool INumberBase<T>.IsSubnormal(T value) => false;
    }
}
