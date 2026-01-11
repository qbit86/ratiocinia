namespace Ratiocinia
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Provides comparison operations for <see cref="Rational{T}" /> with Int32 components
    /// using cross-multiplication via <see cref="Math.BigMul(int, int)" /> to avoid overflow.
    /// </summary>
    public sealed class Int32RationalComparer : IComparer<Rational<int>>
    {
        public static Int32RationalComparer Instance { get; } = new();

        /// <summary>
        /// Compares two <see cref="Rational{T}" /> instances and returns an integer indicating their relative order.
        /// </summary>
        /// <remarks>
        /// Uses cross-multiplication via <see cref="Math.BigMul(int, int)" /> to avoid overflow.
        /// Both denominators must be positive.
        /// </remarks>
        /// <param name="x">The first rational to compare.</param>
        /// <param name="y">The second rational to compare.</param>
        /// <returns>
        /// A negative value if <paramref name="x" /> is less than <paramref name="y" />;
        /// zero if <paramref name="x" /> equals <paramref name="y" />;
        /// a positive value if <paramref name="x" /> is greater than <paramref name="y" />.
        /// </returns>
        public int Compare(Rational<int> x, Rational<int> y)
        {
            long leftProduct = Math.BigMul(x.Numerator, y.Denominator);
            long rightProduct = Math.BigMul(y.Numerator, x.Denominator);

            return leftProduct.CompareTo(rightProduct);
        }
    }
}
