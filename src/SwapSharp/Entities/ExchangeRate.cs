using SwapSharp.Entities.Enums;

namespace SwapSharp.Entities;

/// <summary>
/// The exchange rate returned from the provider
/// </summary>
public class ExchangeRate
{
    /// <summary>
    /// The currency pair which is being measured.
    /// </summary>
    public CurrencyPair CurrencyPair { get; private set; }

    /// <summary>
    /// The value of the rated compared to the base.
    /// </summary>
    public decimal Value { get; private set; }

    public DateTimeOffset Date { get; private set; }

    /// <summary>
    /// The type of the ExchangeRateProvider.
    /// </summary>
    public Type Provider { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="ExchangeRate"/> class.
    /// </summary>
    /// <param name="currencyPair"></param>
    /// <param name="value"></param>
    /// <param name="date"></param>
    /// <param name="provider"></param>
    public ExchangeRate(CurrencyPair currencyPair, decimal value, DateTimeOffset date, Type provider)
    {
        CurrencyPair = currencyPair;
        Value = value;
        Date = date;
        Provider = provider;
    }
}