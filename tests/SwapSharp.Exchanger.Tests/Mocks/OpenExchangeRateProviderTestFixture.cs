using System.IO;
using System.Net.Http;
using SwapSharp.Exchanger.Builders;

namespace SwapSharp.Exchanger.Tests.Mocks;

public class OpenExchangeRateProviderTestFixture
{
    public HttpClient HttpClient;

    public OpenExchangeRateProviderTestFixture()
    {
        using var sr = new StreamReader("Resources/OpenExchangeRateResponse.json");
        var responseData = sr.ReadToEnd();
        HttpClient = new HttpClient(new HttpMessageHandlerFake(responseData));
    }
}