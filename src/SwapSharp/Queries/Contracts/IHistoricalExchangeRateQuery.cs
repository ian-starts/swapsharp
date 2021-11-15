namespace SwapSharp.Queries.Contracts;

/// <summary>
/// Query for getting an ExchangeRate in the past
/// </summary>
public interface IHistoricalExchangeRateQuery : IExchangeRateQuery
{
    /// <summary>
    /// The date at which the ExchangeRate should be fetched
    /// </summary>
    public DateTimeOffset Date { get; }
}