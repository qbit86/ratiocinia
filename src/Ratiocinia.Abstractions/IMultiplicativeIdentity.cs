namespace Ratiocinia
{
    /// <summary>
    /// Defines a mechanism for getting the multiplicative identity of a type.
    /// </summary>
    /// <typeparam name="T">The type that has a multiplicative identity.</typeparam>
    public interface IMultiplicativeIdentity<out T>
    {
        /// <summary>
        /// Gets the multiplicative identity of the current type.
        /// </summary>
        /// <value>The multiplicative identity (typically the value 1).</value>
        T MultiplicativeIdentity { get; }
    }
}
