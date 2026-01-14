namespace Ratiocinia.Models
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Provides a default implementation of <see cref="IComparer{T}" /> for types that implement
    /// <see cref="IComparable{T}" />, delegating comparison to the type's own comparison logic.
    /// </summary>
    /// <typeparam name="T">The type that implements <see cref="IComparable{T}" />.</typeparam>
    public interface IComparableComparer<in T> : IComparer<T>
        where T : IComparable<T>
    {
        /// <inheritdoc />
        int IComparer<T>.Compare(T? x, T? y)
        {
            if (x is not null)
                return x.CompareTo(y);
            if (y is not null)
                return -y.CompareTo(x);
            return 0;
        }
    }
}
