using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SwapSharp.Exchanger.Tests.Mocks;

public class HttpMessageHandlerFake : HttpMessageHandler
{
    private readonly string _responseData;

    public HttpMessageHandlerFake(string responseData)
    {
        _responseData = responseData;
    }

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        return Task.FromResult(
            new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(new MemoryStream(Encoding.UTF8.GetBytes(_responseData)))
            });
    }
}