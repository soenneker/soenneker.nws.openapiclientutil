using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Extensions.ValueTask;
using Soenneker.Nws.OpenApiClientUtil.Abstract;
using Soenneker.Kiota.NoOpAuthenticationProvider;
using Soenneker.Nws.HttpClients.Abstract;
using Soenneker.Nws.OpenApiClient;
using Soenneker.Utils.AsyncSingleton;

namespace Soenneker.Nws.OpenApiClientUtil;

///<inheritdoc cref="INwsOpenApiClientUtil"/>
public sealed class NwsOpenApiClientUtil : INwsOpenApiClientUtil
{
    private readonly AsyncSingleton<NwsOpenApiClient> _client;

    public NwsOpenApiClientUtil(INwsOpenApiHttpClient httpClientUtil)
    {
        _client = new AsyncSingleton<NwsOpenApiClient>(async token =>
        {
            HttpClient httpClient = await httpClientUtil.Get(token)
                                                        .NoSync();
            
            var requestAdapter = new HttpClientRequestAdapter(new NoOpAuthenticationProvider(), httpClient: httpClient);

            return new NwsOpenApiClient(requestAdapter);
        });
    }

    public ValueTask<NwsOpenApiClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
        return _client.DisposeAsync();
    }
}