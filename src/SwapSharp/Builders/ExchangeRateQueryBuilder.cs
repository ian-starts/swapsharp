using SwapSharp.Entities;
using SwapSharp.Queries;

namespace SwapSharp.Builders;

/// <summary>
/// Builder for a query.
/// </summary>
public class ExchangeRateQueryBuilder
{
    /// <summary>
    /// The CurrencyPair that's being queried
    /// </summary>
    public CurrencyPair CurrencyPair { get; private set; }

    /// <summary>
    /// The date at which an ExchangeRate should be requested. 
    /// </summary>
    public DateTimeOffset? Date { get; set; }

    /// <summary>
    /// Options used by a specific provider to set or add functionality like api key or app key
    /// </summary>
    public Dictionary<string, string> Options { get; } = new ();

    /// <summary>
    /// Initializes a new instance of the <see cref="ExchangeRateQueryBuilder"/> class.
    /// </summary>
    /// <param name="currencyPair"></param>
    public ExchangeRateQueryBuilder(CurrencyPair currencyPair)
    {
        CurrencyPair = currencyPair;
    }

    /// <summary>
    /// Ådd an option to the list of options.
    /// </summary>
    /// <param name="key"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public ExchangeRateQueryBuilder SetOption(string key, string value)
    {
        Options.Add(key, value);
        return this;
    }

    /// <summary>
    /// Build the query
    /// </summary>
    /// <returns></returns>
    public ExchangeRateQuery Build()
    {
        return Date != null
            ? new HistoricalExchangeRateQuery(CurrencyPair, Options, Date.Value)
            : new ExchangeRateQuery(CurrencyPair, Options);
    }
}