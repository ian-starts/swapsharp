using SwapSharp.Entities;
using SwapSharp.Queries;

namespace SwapSharp.Providers.Contracts;

/// <summary>
/// Get the historic ExchangeRate.
/// </summary>
public interface IHistoricalExchangeRateProvider
{
    /// <summary>
    /// Get the ExchangeRate on a day in the past.
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public ExchangeRate GetHistoricalExchangeRate(HistoricalExchangeRateQuery query);
}