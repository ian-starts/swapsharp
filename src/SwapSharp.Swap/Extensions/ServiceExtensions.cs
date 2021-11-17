using Microsoft.Extensions.DependencyInjection;
using SwapSharp.Swap.Builders;
using SwapSharp.Swap.Contracts;
using SwapSharp.Swap.Factories;
using SwapSharp.Swap.Factories.Contracts;

namespace SwapSharp.Swap.Extensions;

/// <summary>
/// Extensions for using swap.
/// </summary>
public static class ServiceExtensions
{
    /// <summary>
    /// Add swap to your DI.
    /// </summary>
    /// <param name="servicesCollection"></param>
    /// <param name="builderFactory"></param>
    /// <returns></returns>
    public static IServiceCollection AddSwap(
        this IServiceCollection servicesCollection,
        Action<SwapBuilder, IServiceProvider> builderFactory)
    {
        servicesCollection.AddScoped<IExchangeRateProviderFactory>(
            services => new MicrosoftDiExchangeRateProviderFactory(services));
        servicesCollection.AddHttpClient(nameof(GetType));
        servicesCollection.AddScoped<ISwap>(
            services =>
            {
                var builder = new SwapBuilder(services.GetRequiredService<IExchangeRateProviderFactory>());
                builderFactory.Invoke(builder, services);
                return builder.Build();
            });
        return servicesCollection;
    }

    /// <summary>
    /// Add swap to your DI with ServiceProvider access.
    /// </summary>
    /// <param name="servicesCollection"></param>
    /// <param name="builderFactory"></param>
    /// <returns></returns>
    public static IServiceCollection AddSwap(
        this IServiceCollection servicesCollection,
        Action<SwapBuilder> builderFactory)
    {
        servicesCollection.AddScoped<IExchangeRateProviderFactory>(
            services => new MicrosoftDiExchangeRateProviderFactory(services));
        servicesCollection.AddHttpClient(nameof(GetType));
        servicesCollection.AddScoped<ISwap>(
            services =>
            {
                var builder = new SwapBuilder(services.GetRequiredService<IExchangeRateProviderFactory>());
                builderFactory.Invoke(builder);
                return builder.Build();
            });
        return servicesCollection;
    }
}