using SwapSharp.Entities;
using SwapSharp.Queries.Contracts;

namespace SwapSharp.Queries;

/// <inheritdoc cref="SwapSharp.Queries.Contracts.IHistoricalExchangeRateQuery" />
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
        Dictionary<string, string> options,
        DateTimeOffset date)
        : base(currencyPair, options)
    {
        Date = date;
    }

    /// <inheritdoc/>
    public DateTimeOffset Date { get; private set; }
}