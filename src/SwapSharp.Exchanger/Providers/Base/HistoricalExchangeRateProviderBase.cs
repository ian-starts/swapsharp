using SwapSharp.Exchanger.Entities;
using SwapSharp.Exchanger.Providers.Contracts;
using SwapSharp.Exchanger.Queries;

namespace SwapSharp.Exchanger.Providers.Base;

/// <summary>
/// Base class for defining a provider that can get an historical ExchangeRate.
/// </summary>
public abstract class HistoricalExchangeRateProviderBase : ExchangeRateProviderBase, IHistoricalExchangeRateProvider
{
    /// <inheritdoc />
    public override async Task<ExchangeRate> GetExchangeRate(ExchangeRateQuery query, CancellationToken cancellationToken = default)
    {
        if (query is HistoricalExchangeRateQuery historicalExchangeRateQuery)
        {
            return await GetHistoricalExchangeRate(historicalExchangeRateQuery);
        }

        return await GetCurrentExchangeRate(query, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<ExchangeRate> GetExchangeRate(HistoricalExchangeRateQuery query, CancellationToken cancellationToken = default)
    {
        return await GetHistoricalExchangeRate(query, cancellationToken);
    }

    /// <summary>
    /// Gets the historical ExchangeRate.
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public abstract Task<ExchangeRate> GetHistoricalExchangeRate(HistoricalExchangeRateQuery query, CancellationToken cancellationToken = default);
}