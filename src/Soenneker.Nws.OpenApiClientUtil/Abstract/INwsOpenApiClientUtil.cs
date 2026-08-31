using Soenneker.Nws.OpenApiClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Nws.OpenApiClientUtil.Abstract;

/// <summary>
/// Provides a cached National Weather Service client backed by the configured HTTP provider.
/// </summary>
public interface INwsOpenApiClientUtil : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Gets the cached National Weather Service client, creating it on the first call.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The configured client.</returns>
    ValueTask<NwsOpenApiClient> Get(CancellationToken cancellationToken = default);
}
