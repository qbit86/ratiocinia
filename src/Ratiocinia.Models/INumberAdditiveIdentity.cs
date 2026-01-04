namespace Ratiocinia.Models
{
    using System.Numerics;

    public interface INumberAdditiveIdentity<T> : IAdditiveIdentity<T>
        where T : IAdditiveIdentity<T, T>
    {
        T IAdditiveIdentity<T>.AdditiveIdentity => T.AdditiveIdentity;
    }
}
