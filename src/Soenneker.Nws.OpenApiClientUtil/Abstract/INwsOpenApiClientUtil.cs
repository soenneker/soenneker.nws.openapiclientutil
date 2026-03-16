using Soenneker.Nws.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Nws.OpenApiClientUtil.Abstract;

/// <summary>
/// A .NET thread-safe singleton HttpClient for 
/// </summary>
public interface INwsOpenApiClientUtil: IDisposable, IAsyncDisposable
{
    ValueTask<NwsOpenApiClient> Get(CancellationToken cancellationToken = default);
}
