using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Nws.HttpClients.Registrars;
using Soenneker.Nws.OpenApiClientUtil.Abstract;

namespace Soenneker.Nws.OpenApiClientUtil.Registrars;

/// <summary>
/// A .NET thread-safe singleton HttpClient for GitHub
/// </summary>
public static class NwsOpenApiClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="NwsOpenApiClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddNwsOpenApiClientUtilAsSingleton(this IServiceCollection services)
    {
        services.AddNwsOpenApiHttpClientAsSingleton()
                .TryAddSingleton<INwsOpenApiClientUtil, NwsOpenApiClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="NwsOpenApiClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddNwsOpenApiClientUtilAsScoped(this IServiceCollection services)
    {
        services.AddNwsOpenApiHttpClientAsSingleton()
                .TryAddScoped<INwsOpenApiClientUtil, NwsOpenApiClientUtil>();

        return services;
    }
}
