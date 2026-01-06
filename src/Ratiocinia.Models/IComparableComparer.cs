namespace Ratiocinia.Models
{
    using System;
    using System.Collections.Generic;

    public interface IComparableComparer<in T> : IComparer<T>
        where T : IComparable<T>
    {
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
