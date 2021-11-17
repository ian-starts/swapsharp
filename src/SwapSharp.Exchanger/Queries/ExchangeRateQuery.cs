using SwapSharp.Exchanger.Entities;
using SwapSharp.Exchanger.Queries.Contracts;

namespace SwapSharp.Exchanger.Queries;

/// <inheritdoc />
public class ExchangeRateQuery : IExchangeRateQuery
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ExchangeRateQuery"/> class.
    /// </summary>
    /// <param name="currencyPair"></param>
    /// <param name="options"></param>
    public ExchangeRateQuery(CurrencyPair currencyPair, Dictionary<string, object> options)
    {
        CurrencyPair = currencyPair;
        Options = options;
    }

    /// <inheritdoc/>
    public CurrencyPair CurrencyPair { get; private set; }

    /// <inheritdoc/>
    public Dictionary<string, object> Options { get; private set; }
}