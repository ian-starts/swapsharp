using SwapSharp.Exchanger.Entities;
using SwapSharp.Exchanger.Providers.Contracts;
using SwapSharp.Exchanger.Queries;

namespace SwapSharp.Exchanger.Providers.Base;

/// <summary>
/// Base class for defining a provider that can only get the current ExchangeRate.
/// </summary>
public abstract class ExchangeRateProviderBase : IExchangeRateProvider
{
    /// <inheritdoc />
    public abstract bool SupportsQuery(ExchangeRateQuery exchangeRateQuery);

    /// <inheritdoc/>
    public virtual async Task<ExchangeRate> GetExchangeRate(ExchangeRateQuery query, CancellationToken cancellationToken = default)
    {
        return await GetCurrentExchangeRate(query, cancellationToken);
    }

    /// <summary>
    /// Gets the current ExchangeRate.
    /// </summary>
    /// <param name="query"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public abstract Task<ExchangeRate> GetCurrentExchangeRate(ExchangeRateQuery query, CancellationToken cancellationToken = default);
}