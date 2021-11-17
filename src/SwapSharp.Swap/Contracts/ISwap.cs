using SwapSharp.Exchanger.Entities;

namespace SwapSharp.Swap.Contracts;

/// <summary>
/// Defines what a swap implementation should do.
/// </summary>
public interface ISwap
{
    /// <summary>
    /// Gets the latest ExchangeRate for a CurrencyPair.
    /// </summary>
    /// <param name="currencyPair"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<ExchangeRate> Latest(CurrencyPair currencyPair, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets the historical ExchangeRate for a CurrencyPair.
    /// </summary>
    /// <param name="currencyPair"></param>
    /// <param name="dateTime"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public Task<ExchangeRate> Historical(
        CurrencyPair currencyPair,
        DateTimeOffset dateTime,
        CancellationToken cancellationToken = default);
}