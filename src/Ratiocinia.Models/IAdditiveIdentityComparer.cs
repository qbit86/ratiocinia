namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    public interface IAdditiveIdentityComparer<T> : IComparable<T>, IEquatable<T>
        where T : IAdditiveIdentity<T, T>, IComparable<T>
    {
        int IComparable<T>.CompareTo(T? other) => T.AdditiveIdentity.CompareTo(other);

        bool IEquatable<T>.Equals(T? other) => T.AdditiveIdentity.CompareTo(other) is 0;
    }
}
