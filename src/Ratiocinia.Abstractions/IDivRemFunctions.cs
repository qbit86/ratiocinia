namespace Ratiocinia
{
    public interface IDivRemFunctions<T>
    {
        (T Quotient, T Remainder) DivRem(T left, T right);
    }
}
