using Microsoft.Extensions.Caching.Distributed;
using SwapSharp.Exchanger.Providers.Contracts;

namespace SwapSharp.Swap.Factories.Contracts;

/// <summary>
/// Factory for creating an ExchangeRateProvider using reflection.
/// </summary>
public interface IExchangeRateProviderFactory
{
    /// <summary>
    /// Create a provider based in the generic type.
    /// </summary>
    /// <param name="httpClient"></param>
    /// <param name="distributedCache"></param>
    /// <param name="options"></param>
    /// <typeparam name="T">An IExchangeRateProvider.</typeparam>
    /// <returns></returns>
    public IExchangeRateProvider Create<T>(
        HttpClient? httpClient,
        IDistributedCache? distributedCache,
        IDictionary<string, object> options)
        where T : IExchangeRateProvider;

    /// <summary>
    /// Create a provider.
    /// </summary>
    /// <param name="t">Must be of type IExchangeRateProvider.</param>
    /// <param name="httpClient"></param>
    /// <param name="distributedCache"></param>
    /// <param name="options"></param>
    /// <returns></returns>
    public IExchangeRateProvider Create(
        Type t,
        HttpClient? httpClient,
        IDistributedCache? distributedCache,
        IDictionary<string, object> options);
}