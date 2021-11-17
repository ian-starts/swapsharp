using System.Collections.Generic;
using FluentAssertions;
using SwapSharp.Exchanger.Builders;
using SwapSharp.Exchanger.Entities;
using SwapSharp.Exchanger.Entities.Enums;
using SwapSharp.Exchanger.Providers;
using SwapSharp.Exchanger.Tests.Mocks;
using Xunit;

namespace SwapSharp.Exchanger.Tests.Providers;

public class OpenExchangeRateProviderTests:  IClassFixture<OpenExchangeRateProviderTestFixture>
{
    private readonly OpenExchangeRateProviderTestFixture _fixture;

    public OpenExchangeRateProviderTests(OpenExchangeRateProviderTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Fact]
    public void GetCurrentExchangeRate_WithValidPair_ReturnsCurrentExchangeRate()
    {
        // Arrange
        var options = new Dictionary<string, object> { { "app_id", "1234" } };
        var currencyPair = new CurrencyPair(Currency.USD, Currency.EUR);
        var builder = new ExchangeRateQueryBuilder(currencyPair);
        var provider = new OpenExchangeRatesProvider(_fixture.HttpClient, null, options);
        
        // Act
        var rate = provider.GetCurrentExchangeRate(builder.Build()).Result;
        
        // Assert
        rate.Should().NotBeNull();
    }
}