namespace Ratiocinia
{
    public interface IAdditiveIdentity<out T>
    {
        T AdditiveIdentity { get; }
    }
}
