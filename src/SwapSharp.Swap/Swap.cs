using SwapSharp.Exchanger.Builders;
using SwapSharp.Exchanger.Entities;
using SwapSharp.Exchanger.Exceptions;
using SwapSharp.Exchanger.Providers.Contracts;
using SwapSharp.Exchanger.Queries;
using SwapSharp.Swap.Contracts;

namespace SwapSharp.Swap;

/// <inheritdoc />
public class Swap : ISwap
{
    private readonly IHistoricalExchangeRateProvider _exchangeRateProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="Swap"/> class.
    /// </summary>
    /// <param name="exchangeRateProvider"></param>
    public Swap(IHistoricalExchangeRateProvider exchangeRateProvider)
    {
        _exchangeRateProvider = exchangeRateProvider;
    }

    /// <inheritdoc/>
    public async Task<ExchangeRate> Latest(CurrencyPair currencyPair, CancellationToken cancellationToken = default)
    {
        return await Quote(currencyPair, cancellationToken: cancellationToken);
    }

    /// <inheritdoc/>
    public async Task<ExchangeRate> Historical(CurrencyPair currencyPair, DateTimeOffset dateTime, CancellationToken cancellationToken = default)
    {
        return await Quote(currencyPair, dateTime, cancellationToken);
    }

    private async Task<ExchangeRate> Quote(CurrencyPair currencyPair, DateTimeOffset? dateTime = null, CancellationToken cancellationToken = default)
    {
        var builder = new ExchangeRateQueryBuilder(currencyPair);
        if (dateTime != null)
        {
            builder.Date = dateTime;
        }

        var query = builder.Build();
        if (_exchangeRateProvider.SupportsQuery(query))
        {
            return await _exchangeRateProvider.GetExchangeRate(builder.Build(), cancellationToken);
        }

        throw new InvalidQueryException();
    }
}