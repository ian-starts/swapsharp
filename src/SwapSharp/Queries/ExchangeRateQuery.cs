using SwapSharp.Entities;
using SwapSharp.Queries.Contracts;

namespace SwapSharp.Queries;

/// <inheritdoc />
public class ExchangeRateQuery : IExchangeRateQuery
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ExchangeRateQuery"/> class.
    /// </summary>
    /// <param name="currencyPair"></param>
    /// <param name="options"></param>
    public ExchangeRateQuery(CurrencyPair currencyPair, Dictionary<string, string> options)
    {
        CurrencyPair = currencyPair;
        Options = options;
    }

    /// <inheritdoc/>
    public CurrencyPair CurrencyPair { get; private set; }

    /// <inheritdoc/>
    public Dictionary<string, string> Options { get; private set; }
}