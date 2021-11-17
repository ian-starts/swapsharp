using System.Text;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using SwapSharp.Exchanger.Entities;
using SwapSharp.Exchanger.Exceptions;
using SwapSharp.Exchanger.Extensions;
using SwapSharp.Exchanger.Providers.Base;
using SwapSharp.Exchanger.Providers.Contracts;
using SwapSharp.Exchanger.Queries;

namespace SwapSharp.Exchanger.Providers;

/// <summary>
/// Get the historic ExchangeRate and today's ExchangeRate.
/// </summary>
public class OpenExchangeRatesProvider : HistoricalExchangeRateProviderBase
{
    private const string FreeLatestUrl = "https://openexchangerates.org/api/latest.json?app_id={0}&show_alternative=1";

    private const string EnterpriseLatestUrl =
        "https://openexchangerates.org/api/latest.json?app_id={0}&base={1}&symbols={2}&show_alternative=1";

    private const string FreeHistoricalUrl =
        "https://openexchangerates.org/api/historical/{0}.json?app_id={1}&show_alternative=1";

    private const string EnterpriseHistoricalUrl =
        "https://openexchangerates.org/api/historical/{0}.json?app_id={1}&base={2}&symbols={3}&show_alternative=1";

    private readonly HttpClient _httpClient;

    private readonly IDistributedCache? _cache;

    private readonly IDictionary<string, object> _options;

    /// <summary>
    /// Initializes a new instance of the <see cref="OpenExchangeRatesProvider"/> class.
    /// </summary>
    /// <param name="httpClient"></param>
    /// <param name="cache"></param>
    /// <param name="options"></param>
    public OpenExchangeRatesProvider(
        HttpClient httpClient,
        IDistributedCache? cache,
        IDictionary<string, object> options)
    {
        _httpClient = httpClient;
        _cache = cache;
        _options = options;
    }

    /// <inheritdoc />
    public override Task<ExchangeRate> GetHistoricalExchangeRate(
        HistoricalExchangeRateQuery query,
        CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }


    /// <inheritdoc />
    public override async Task<ExchangeRate> GetCurrentExchangeRate(
        ExchangeRateQuery query,
        CancellationToken cancellationToken = default)
    {
        var allOptions = _options.AddQueryOptions(query);
        var url = string.Empty;
        if (allOptions.TryGetValue("enterprise", out var enterprise))
        {
            if ((bool)enterprise)
            {
                url = string.Format(
                    EnterpriseLatestUrl,
                    allOptions["app_id"],
                    allOptions[query.CurrencyPair.BaseCurrency.ToString()],
                    allOptions[query.CurrencyPair.QuoteCurrency.ToString()]);
            }
            else
            {
                url = string.Format(
                    FreeLatestUrl,
                    allOptions["app_id"]);
            }
        }
        else
        {
            url = string.Format(
                FreeLatestUrl,
                allOptions["app_id"]);
        }

        return await GetExchangeRateFromUrl(url, query, cancellationToken);
    }

    /// <inheritdoc />
    public override bool SupportsQuery(ExchangeRateQuery exchangeRateQuery)
    {
        if (!_options.TryGetValue("app_id", out _) && !exchangeRateQuery.Options.TryGetValue("app_id", out _))
        {
            throw new ApiKeyNotSetException($"{nameof(GetType)} requires the app_id to be set");
        }

        return true;
    }

    private async Task<ExchangeRate> GetExchangeRateFromUrl(
        string url,
        ExchangeRateQuery query,
        CancellationToken cancellationToken = default)
    {
        if (query.CurrencyPair.IsIdentical())
        {
            return new ExchangeRate(query.CurrencyPair, 1, DateTimeOffset.Now, GetType());
        }

        var response = await GetExchangeRateResponse(url, cancellationToken);
        var jsonData = JsonConvert.DeserializeObject<JToken>(response);
        var dateTime = DateTimeOffset.FromUnixTimeSeconds((int)jsonData["timestamp"]);
        if ((string)jsonData["base"] == query.CurrencyPair.BaseCurrency.ToString()
            && jsonData["rates"][$"{query.CurrencyPair.QuoteCurrency}"] != null)
        {
            return new ExchangeRate(
                query.CurrencyPair,
                (decimal)jsonData["rates"][$"{query.CurrencyPair.QuoteCurrency}"],
                dateTime,
                GetType());
        }

        throw new Exception();
    }

    private async Task<string> GetExchangeRateResponse(string url, CancellationToken cancellationToken = default)
    {
        // if no cache is present, just get from url.
        if (_cache == null)
        {
            return await _httpClient.GetStringAsync(url, cancellationToken);
        }


        // Try get cache hit based on url
        var cachedResponse = await _cache.GetAsync(url, cancellationToken);
        if (cachedResponse != null)
        {
            return Encoding.UTF8.GetString(cachedResponse);
        }

        // no hit so get the data from the endpoint and set in cache.
        var response = await _httpClient.GetStringAsync(url, cancellationToken);
        await _cache.SetStringAsync(
            url,
            response,
            new DistributedCacheEntryOptions()
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(24),
            },
            cancellationToken);
        return response;
    }
}