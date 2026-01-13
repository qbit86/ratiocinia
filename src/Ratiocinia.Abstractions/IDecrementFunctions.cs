namespace Ratiocinia
{
    /// <summary>
    /// Defines a mechanism for decrementing a value.
    /// </summary>
    /// <typeparam name="T">The type of value to decrement.</typeparam>
    public interface IDecrementFunctions<T>
    {
        /// <summary>
        /// Decrements a value by one.
        /// </summary>
        /// <param name="value">The value to decrement.</param>
        /// <returns>The result of decrementing <paramref name="value" /> by one.</returns>
        T Decrement(T value);
    }
}
