using SwapSharp.Exchanger.Entities;
using SwapSharp.Exchanger.Providers.Contracts;
using SwapSharp.Exchanger.Queries;
using SwapSharp.Exchanger.Queries.Contracts;

namespace SwapSharp.Exchanger.Providers;

/// <inheritdoc />
public class ChainedExchangeRateProviderAdapter : IHistoricalExchangeRateProvider
{
    private readonly IEnumerable<IExchangeRateProvider> _exchangeRateProviders;

    /// <summary>
    /// Initializes a new instance of the <see cref="ChainedExchangeRateProviderAdapter"/> class.
    /// </summary>
    /// <param name="exchangeRateProviders"></param>
    public ChainedExchangeRateProviderAdapter(IEnumerable<IExchangeRateProvider> exchangeRateProviders)
    {
        _exchangeRateProviders = exchangeRateProviders;
    }

    /// <inheritdoc />
    public bool SupportsQuery(ExchangeRateQuery exchangeRateQuery)
    {
        return _exchangeRateProviders.Any(provider => provider.SupportsQuery(exchangeRateQuery));
    }

    /// <inheritdoc />
    public Task<ExchangeRate> GetExchangeRate(ExchangeRateQuery query, CancellationToken cancellationToken = default)
    {
        return _exchangeRateProviders.First(e => e.SupportsQuery(query)).GetExchangeRate(query, cancellationToken);
    }

    /// <inheritdoc />
    public Task<ExchangeRate> GetExchangeRate(HistoricalExchangeRateQuery query, CancellationToken cancellationToken = default)
    {
        return _exchangeRateProviders.First(e => e.SupportsQuery(query)).GetExchangeRate(query, cancellationToken);
    }
}