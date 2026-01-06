namespace Ratiocinia.Models
{
    using System.Numerics;

    public interface INumberBaseAbsoluteFunctions<T> : IAbsoluteFunctions<T>
        where T : INumberBase<T>
    {
        T IAbsoluteFunctions<T>.Abs(T value) => T.Abs(value);
    }
}
