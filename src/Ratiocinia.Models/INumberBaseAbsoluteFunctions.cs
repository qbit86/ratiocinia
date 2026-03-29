namespace Ratiocinia.Models
{
    using System.Numerics;
    using MathFoundations;

    /// <summary>
    /// Provides a default implementation of <see cref="IAbs{T}" /> for types
    /// that implement <see cref="INumberBase{TSelf}" />, using the type's built-in absolute value function.
    /// </summary>
    /// <typeparam name="T">The numeric type that implements <see cref="INumberBase{TSelf}" />.</typeparam>
    public interface INumberBaseAbsoluteFunctions<T> : IAbs<T>
        where T : INumberBase<T>
    {
        /// <inheritdoc />
        T IAbs<T>.Abs(T value) => T.Abs(value);
    }
}
