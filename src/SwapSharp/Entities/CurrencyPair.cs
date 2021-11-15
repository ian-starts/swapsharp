using SwapSharp.Entities.Enums;

namespace SwapSharp.Entities;

/// <summary>
/// A pair of currencies that will be compared.
/// </summary>
public class CurrencyPair
{
    /// <summary>
    /// The base currency compaired against
    /// </summary>
    public Currency BaseCurrency { get; private set; }

    /// <summary>
    /// The currency that needs to be compared to
    /// </summary>
    public Currency QuoteCurrency { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="CurrencyPair"/> class.
    /// </summary>
    /// <param name="baseCurrency"></param>
    /// <param name="quoteCurrency"></param>
    public CurrencyPair(Currency baseCurrency, Currency quoteCurrency)
    {
        BaseCurrency = baseCurrency;
        QuoteCurrency = quoteCurrency;
    }
}