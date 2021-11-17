using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using SwapSharp.Exchanger.Providers.Contracts;
using SwapSharp.Swap.Factories.Contracts;

namespace SwapSharp.Swap.Factories;

/// <inheritdoc />
public class MicrosoftDiExchangeRateProviderFactory : IExchangeRateProviderFactory
{
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Initializes a new instance of the <see cref="MicrosoftDiExchangeRateProviderFactory"/> class.
    /// </summary>
    /// <param name="serviceProvider"></param>
    public MicrosoftDiExchangeRateProviderFactory(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    /// <inheritdoc/>
    public IExchangeRateProvider Create<T>(
        HttpClient? httpClient,
        IDistributedCache? distributedCache,
        IDictionary<string, object> options)
        where T : IExchangeRateProvider
    {
        return Create(typeof(T), httpClient, distributedCache, options);
    }

    /// <inheritdoc/>
    public IExchangeRateProvider Create(
        Type t,
        HttpClient? httpClient,
        IDistributedCache? distributedCache,
        IDictionary<string, object> options)
    {
        if (!t.GetInterfaces().Contains(typeof(IExchangeRateProvider)))
        {
            throw new ArgumentException("the type of t must be of type IExchangeRateProvider");
        }

        var usedHttpClient = httpClient;
        var usedCache = distributedCache;
        if (httpClient == null)
        {
            usedHttpClient =
                _serviceProvider.GetRequiredService<IHttpClientFactory>()
                .CreateClient(nameof(GetType));
        }

        if (distributedCache == null)
        {
            usedCache =
                _serviceProvider.GetService<IDistributedCache>();
        }

        return (IExchangeRateProvider)Activator.CreateInstance(t, usedHttpClient, usedCache, options) ! ??
               throw new InvalidOperationException();
    }
}