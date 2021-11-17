using SwapSharp.Exchanger.Entities;

namespace SwapSharp.Exchanger.Extensions;

/// <summary>
/// Class for extending functionality on CurrencyPair.
/// </summary>
public static class CurrencyPairExtensions
{
    /// <summary>
    /// Checks if the two have identical currencies.
    /// </summary>
    /// <param name="pair"></param>
    /// <returns></returns>
    public static bool IsIdentical(this CurrencyPair pair)
    {
        return pair.BaseCurrency == pair.QuoteCurrency;
    }
}