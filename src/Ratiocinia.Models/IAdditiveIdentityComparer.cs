namespace Ratiocinia.Models
{
    using System;
    using System.Numerics;

    public interface IAdditiveIdentityComparer<in T> : IComparable<T>
        where T : IAdditiveIdentity<T, T>, IComparable<T>
    {
        int IComparable<T>.CompareTo(T? other) => T.AdditiveIdentity.CompareTo(other);
    }
}
