using SwapSharp.Entities;

namespace SwapSharp.Queries.Contracts;

/// <summary>
/// Query for a provider
/// </summary>
public interface IExchangeRateQuery
{
    /// <summary>
    /// What currencies should be requested.
    /// </summary>
    public CurrencyPair CurrencyPair { get; }

    /// <summary>
    /// Options used by a specific provider to set or add functionality like api key or app key
    /// </summary>
    public Dictionary<string, string> Options { get; }
}