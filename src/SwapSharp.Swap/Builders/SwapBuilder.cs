using Microsoft.Extensions.Caching.Distributed;
using SwapSharp.Exchanger.Providers;
using SwapSharp.Exchanger.Providers.Contracts;
using SwapSharp.Swap.Factories.Contracts;

namespace SwapSharp.Swap.Builders;

/// <summary>
/// Builder for an instance of swap.
/// </summary>
public class SwapBuilder
{
    private readonly Dictionary<Type, IDictionary<string, object>> _registeredTypes;

    private readonly IExchangeRateProviderFactory _exchangeRateProviderFactory;

    private HttpClient? _httpClient;

    private IDistributedCache? _distributedCache;

    /// <summary>
    /// Initializes a new instance of the <see cref="SwapBuilder"/> class.
    /// </summary>
    /// <param name="exchangeRateProviderFactory"></param>
    public SwapBuilder(IExchangeRateProviderFactory exchangeRateProviderFactory)
    {
        _exchangeRateProviderFactory = exchangeRateProviderFactory;
        _registeredTypes = new Dictionary<Type, IDictionary<string, object>>();
    }

    /// <summary>
    /// Add provider with fallback logic to the builder.
    /// </summary>
    /// <param name="configurationFactory"></param>
    /// <typeparam name="T">The provider you want to add.</typeparam>
    /// <returns></returns>
    public SwapBuilder Add<T>(Action<IDictionary<string, object>> configurationFactory)
        where T : IExchangeRateProvider
    {
        var config = new Dictionary<string, object>();
        configurationFactory.Invoke(config);
        _registeredTypes.Add(typeof(T), config);
        return this;
    }

    /// <summary>
    /// Overwrite which cache to use.
    /// </summary>
    /// <param name="cache"></param>
    /// <returns></returns>
    public SwapBuilder UseCache(IDistributedCache cache)
    {
        _distributedCache = cache;
        return this;
    }

    /// <summary>
    /// Overwrite with custom httpclient if wanted.
    /// </summary>
    /// <param name="httpClient"></param>
    /// <returns></returns>
    public SwapBuilder UseHttpClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
        return this;
    }

    /// <summary>
    /// Build the swap instance.
    /// </summary>
    /// <returns></returns>
    public Swap Build()
    {
        var exchangeRateProviders = _registeredTypes.Select(
            rt => _exchangeRateProviderFactory.Create(rt.Key, _httpClient, _distributedCache, rt.Value));
        var chain = new ChainedExchangeRateProviderAdapter(exchangeRateProviders);
        return new Swap(chain);
    }
}