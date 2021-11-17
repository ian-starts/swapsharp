using SwapSharp.Exchanger.Entities;
using SwapSharp.Exchanger.Queries;

namespace SwapSharp.Exchanger.Providers.Contracts;

/// <summary>
/// Get current ExchangeRate of today.
/// </summary>
public interface IExchangeRateProvider
{
    /// <summary>
    /// Checks if the query is supported but the provider.
    /// </summary>
    /// <param name="exchangeRateQuery"></param>
    /// <returns></returns>
    public bool SupportsQuery(ExchangeRateQuery exchangeRateQuery);

    /// <summary>
    /// Get the ExchangeRate based on the query.
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<ExchangeRate> GetExchangeRate(ExchangeRateQuery query, CancellationToken cancellationToken = default);
}