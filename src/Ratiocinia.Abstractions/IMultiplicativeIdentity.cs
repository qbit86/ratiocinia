namespace Ratiocinia
{
    public interface IMultiplicativeIdentity<out T>
    {
        T MultiplicativeIdentity { get; }
    }
}
