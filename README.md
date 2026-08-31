[![](https://img.shields.io/nuget/v/soenneker.nws.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.nws.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.nws.openapiclientutil/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.nws.openapiclientutil/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.nws.openapiclientutil.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.nws.openapiclientutil/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.nws.openapiclientutil/codeql.yml?style=for-the-badge&label=codeql)](https://github.com/soenneker/soenneker.nws.openapiclientutil/actions/workflows/codeql.yml)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Nws.OpenApiClientUtil

Provides a configured National Weather Service client and reuses it for the lifetime of the registered service.

## Installation

```bash
dotnet add package Soenneker.Nws.OpenApiClientUtil
```

## Configuration

```json
{
  "Nws": {
    "UserAgent": "my-weather-app/1.0 (contact@example.com)"
  }
}
```

## Usage

```csharp
using Soenneker.Nws.OpenApiClientUtil.Abstract;
using Soenneker.Nws.OpenApiClientUtil.Registrars;

services.AddNwsOpenApiClientUtilAsSingleton();

INwsOpenApiClientUtil nws = serviceProvider
    .GetRequiredService<INwsOpenApiClientUtil>();

var client = await nws.Get(cancellationToken);
var alertTypes = await client.Alerts.Types.GetAsync(cancellationToken: cancellationToken);
```

Use `AddNwsOpenApiClientUtilAsScoped()` when each application scope should have its own generated client wrapper. The underlying HTTP provider remains shared and is disposed by the service container at shutdown.
