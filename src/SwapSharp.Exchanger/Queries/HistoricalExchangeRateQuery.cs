using SwapSharp.Exchanger.Entities;
using SwapSharp.Exchanger.Queries.Contracts;

namespace SwapSharp.Exchanger.Queries;

/// <inheritdoc cref="IHistoricalExchangeRateQuery" />
public class HistoricalExchangeRateQuery : ExchangeRateQuery, IHistoricalExchangeRateQuery
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HistoricalExchangeRateQuery"/> class.
    /// </summary>
    /// <param name="currencyPair"></param>
    /// <param name="options"></param>
    /// <param name="date"></param>
    public HistoricalExchangeRateQuery(
        CurrencyPair currencyPair,
        Dictionary<string, object> options,
        DateTimeOffset date)
        : base(currencyPair, options)
    {
        Date = date;
    }

    /// <inheritdoc/>
    public DateTimeOffset Date { get; private set; }
}