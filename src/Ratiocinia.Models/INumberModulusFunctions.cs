namespace Ratiocinia.Models
{
    using System.Numerics;

    public interface INumberModulusFunctions<T> : IModulusFunctions<T>
        where T : IModulusOperators<T, T, T>
    {
        T IModulusFunctions<T>.Modulus(T left, T right) => left % right;
    }
}
