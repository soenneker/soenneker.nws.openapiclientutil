using Soenneker.Nws.OpenApiClientUtil.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Nws.OpenApiClientUtil.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class NwsOpenApiClientUtilTests : HostedUnitTest
{
    private readonly INwsOpenApiClientUtil _openapiclientutil;

    public NwsOpenApiClientUtilTests(Host host) : base(host)
    {
        _openapiclientutil = Resolve<INwsOpenApiClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
