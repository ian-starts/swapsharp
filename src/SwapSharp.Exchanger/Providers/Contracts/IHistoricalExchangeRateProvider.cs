using SwapSharp.Exchanger.Entities;
using SwapSharp.Exchanger.Queries;

namespace SwapSharp.Exchanger.Providers.Contracts;

/// <summary>
/// Get the historic ExchangeRate.
/// </summary>
public interface IHistoricalExchangeRateProvider : IExchangeRateProvider
{
    /// <summary>
    /// Get the ExchangeRate on a day in the past.
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<ExchangeRate> GetExchangeRate(HistoricalExchangeRateQuery query, CancellationToken cancellationToken = default);
}