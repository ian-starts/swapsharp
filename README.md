# SwapSharp
SwapSharp is a C# implementation of the popular [exchanger framework](https://github.com/florianv/exchanger) and it's implementation: [swap](https://github.com/florianv/swap).

It allows you to retrieve currency exchange from different providers. It currently only supports [Open Exchange Rate](https://openexchangerates.org/).
## Quickstart
The easiest way to get going is by using the ServiceExtensions for Microsoft DependencyInjection. To do this simply add the following to your `ServiceCollection`.

```shell
dotnet add package SwapSharp --version 0.0.1
```

```c#
Services.AddSwap(
    builder =>
    {
        builder.Add<OpenExchangeRatesProvider>(
            config =>
            {
                config.Add("app_id", "your_app_id");
                config.Add("enterprise", false);
            });
    });
```
This was built rather hastily and there are definitely some corners that I've cut, so PR's are most welcome.