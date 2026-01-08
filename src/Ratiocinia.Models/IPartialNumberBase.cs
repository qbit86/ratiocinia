namespace Ratiocinia.Models
{
    using System.Numerics;

    public interface IPartialNumberBase<T> : INumberBase<T> where T : INumberBase<T>
    {
        static bool INumberBase<T>.IsCanonical(T value) => true;

        static bool INumberBase<T>.IsComplexNumber(T value) => false;

        static bool INumberBase<T>.IsFinite(T value) => true;

        static bool INumberBase<T>.IsImaginaryNumber(T value) => false;

        static bool INumberBase<T>.IsInfinity(T value) => false;

        static bool INumberBase<T>.IsNaN(T value) => false;

        static bool INumberBase<T>.IsNegativeInfinity(T value) => false;

        static bool INumberBase<T>.IsPositiveInfinity(T value) => false;

        static bool INumberBase<T>.IsRealNumber(T value) => true;

        static bool INumberBase<T>.IsSubnormal(T value) => false;
    }
}
