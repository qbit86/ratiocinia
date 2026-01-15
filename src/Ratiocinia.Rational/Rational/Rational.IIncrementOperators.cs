namespace Ratiocinia
{
    partial struct Rational<T>
    {
        /// <summary>
        /// Increments a rational number by one.
        /// </summary>
        /// <param name="value">The rational number to increment.</param>
        /// <returns>The value of <paramref name="value" /> incremented by one.</returns>
        public static Rational<T> operator ++(Rational<T> value) => Increment(value);

        /// <summary>
        /// Increments a rational number by one with overflow checking.
        /// </summary>
        /// <param name="value">The rational number to increment.</param>
        /// <returns>The value of <paramref name="value" /> incremented by one.</returns>
        /// <exception cref="System.OverflowException">
        /// Thrown when the operation causes an arithmetic overflow.
        /// </exception>
        public static Rational<T> operator checked ++(Rational<T> value) =>
            UnsafeCreate(checked(value.Numerator + value.Denominator), value.Denominator);

        /// <summary>
        /// Increments a rational number by one.
        /// </summary>
        /// <param name="value">The rational number to increment.</param>
        /// <returns>The value of <paramref name="value" /> incremented by one.</returns>
        public static Rational<T> Increment(Rational<T> value) =>
            UnsafeCreate(value.Numerator + value.Denominator, value.Denominator);
    }
}
