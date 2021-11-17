using SwapSharp.Exchanger.Entities;
using SwapSharp.Exchanger.Queries;

namespace SwapSharp.Exchanger.Builders;

/// <summary>
/// Builder for a query.
/// </summary>
public class ExchangeRateQueryBuilder
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ExchangeRateQueryBuilder"/> class.
    /// </summary>
    /// <param name="currencyPair"></param>
    public ExchangeRateQueryBuilder(CurrencyPair currencyPair)
    {
        CurrencyPair = currencyPair;
    }

    /// <summary>
    /// Gets the currency pair.
    /// </summary>
    public CurrencyPair CurrencyPair { get; private set; }

    /// <summary>
    /// Gets or sets the date at which an ExchangeRate should be requested.
    /// </summary>
    public DateTimeOffset? Date { get; set; }

    /// <summary>
    /// Gets options used by a specific provider to set or add functionality like api key or app key.
    /// </summary>
    public Dictionary<string, object> Options { get; } = new ();

    /// <summary>
    /// Add an option to the list of options.
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
    /// Build the query.
    /// </summary>
    /// <returns></returns>
    public ExchangeRateQuery Build()
    {
        return Date != null
            ? new HistoricalExchangeRateQuery(CurrencyPair, Options, Date.Value)
            : new ExchangeRateQuery(CurrencyPair, Options);
    }
}