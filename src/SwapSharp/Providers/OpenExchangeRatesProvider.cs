using SwapSharp.Entities;
using SwapSharp.Providers.Contracts;
using SwapSharp.Queries;

namespace SwapSharp.Providers;

public class OpenExchangeRatesProvider : IExchangeRateProvider
{
    private readonly HttpClient _httpClient;

    public OpenExchangeRatesProvider(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public ExchangeRate GetExchangeRate(ExchangeRateQuery query)
    {
        throw new NotImplementedException();
    }
}