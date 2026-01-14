namespace Ratiocinia
{
    partial struct Rational<T>
    {
        /// <summary>
        /// Returns the unary plus of a rational number (the value unchanged).
        /// </summary>
        /// <param name="value">The rational number.</param>
        /// <returns>The value of <paramref name="value" /> unchanged.</returns>
        public static Rational<T> operator +(Rational<T> value) => value;

        /// <summary>
        /// Returns the unary plus of a rational number (the value unchanged).
        /// </summary>
        /// <param name="value">The rational number.</param>
        /// <returns>The value of <paramref name="value" /> unchanged.</returns>
        public static Rational<T> Plus(Rational<T> value) => value;
    }
}
