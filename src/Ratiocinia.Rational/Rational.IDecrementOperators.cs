namespace Ratiocinia
{
    partial struct Rational<T>
    {
        /// <summary>
        /// Decrements a rational number by one.
        /// </summary>
        /// <param name="value">The rational number to decrement.</param>
        /// <returns>The value of <paramref name="value" /> decremented by one.</returns>
        public static Rational<T> operator --(Rational<T> value) => Decrement(value);

        /// <summary>
        /// Decrements a rational number by one with overflow checking.
        /// </summary>
        /// <param name="value">The rational number to decrement.</param>
        /// <returns>The value of <paramref name="value" /> decremented by one.</returns>
        /// <exception cref="System.OverflowException">
        /// Thrown when the operation causes an arithmetic overflow.
        /// </exception>
        public static Rational<T> operator checked --(Rational<T> value) =>
            UnsafeCreate(checked(value.Numerator - value.Denominator), value.Denominator);

        /// <summary>
        /// Decrements a rational number by one.
        /// </summary>
        /// <param name="value">The rational number to decrement.</param>
        /// <returns>The value of <paramref name="value" /> decremented by one.</returns>
        public static Rational<T> Decrement(Rational<T> value) =>
            UnsafeCreate(value.Numerator - value.Denominator, value.Denominator);
    }
}
