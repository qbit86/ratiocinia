namespace System.Runtime.CompilerServices
{
    using ComponentModel;

    /// <summary>
    /// Polyfill to enable record types and init-only setters in netstandard2.0.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal static class IsExternalInit;
}
