using SwapSharp.Entities;
using SwapSharp.Queries;

namespace SwapSharp.Providers.Contracts;

/// <summary>
/// Get current ExchangeRate of today.
/// </summary>
public interface IExchangeRateProvider
{
    /// <summary>
    /// Get the ExchangeRate based on the query.
    /// </summary>
    /// <param name="query"></param>
    /// <returns></returns>
    public ExchangeRate GetExchangeRate(ExchangeRateQuery query);
}