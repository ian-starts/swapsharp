namespace SwapSharp.Exchanger.Exceptions;

/// <summary>
/// Error when api key is not set as option in request.
/// </summary>
public class ApiKeyNotSetException : Exception
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ApiKeyNotSetException"/> class.
    /// </summary>
    /// <param name="message"></param>
    public ApiKeyNotSetException(string message)
        : base(message)
    {
    }
}