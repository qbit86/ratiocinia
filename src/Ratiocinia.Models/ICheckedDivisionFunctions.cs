namespace Ratiocinia.Models
{
    using System.Numerics;

    public interface ICheckedDivisionFunctions<T> : IDivisionFunctions<T>
        where T : IDivisionOperators<T, T, T>
    {
        T IDivisionFunctions<T>.Divide(T left, T right) => checked(left / right);
    }
}
