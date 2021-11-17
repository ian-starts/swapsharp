using SwapSharp.Exchanger.Queries;

namespace SwapSharp.Exchanger.Extensions;

/// <summary>
/// Extensions for Dictionary.
/// </summary>
public static class DictionaryExtensions
{
    /// <summary>
    /// Merges all options used in a request.
    /// </summary>
    /// <param name="dictionary"></param>
    /// <param name="query"></param>
    /// <returns></returns>
    public static IDictionary<string, object> AddQueryOptions(
        this IDictionary<string, object> dictionary,
        ExchangeRateQuery query)
    {
        var options = dictionary.ToList();
        var queryOptions = query.Options.ToList();
        options.AddRange(queryOptions);
        var distinctOptions = options.DistinctBy(k => k.Key);
        return new Dictionary<string, object>(distinctOptions);
    }
}