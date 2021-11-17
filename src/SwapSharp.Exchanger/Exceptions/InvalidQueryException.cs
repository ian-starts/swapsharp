using SwapSharp.Exchanger.Queries;

namespace SwapSharp.Exchanger.Exceptions;

/// <summary>
/// Thrown when the query is not accepted by the provider. 
/// </summary>
public class InvalidQueryException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvalidQueryException"/> class.
    /// </summary>
    public InvalidQueryException()
    {
    }
}