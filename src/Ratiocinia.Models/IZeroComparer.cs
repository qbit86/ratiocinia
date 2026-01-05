namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    public interface IZeroComparer<T> : IComparable<T>, IEquatable<T>
        where T : INumberBase<T>
    {
        int IComparable<T>.CompareTo(T? other)
        {
            if (other is null || T.IsZero(other))
                return 0;

            if (T.IsNegative(other))
                return 1;

            if (T.IsPositive(other))
                return -1;

            throw new InvalidOperationException();
        }

        bool IEquatable<T>.Equals(T? other) => other is null || T.IsZero(other);
    }
}
