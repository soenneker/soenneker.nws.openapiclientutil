using Soenneker.Nws.OpenApiClientUtil.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Nws.OpenApiClientUtil.Tests;

[Collection("Collection")]
public sealed class NwsOpenApiClientUtilTests : FixturedUnitTest
{
    private readonly INwsOpenApiClientUtil _openapiclientutil;

    public NwsOpenApiClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _openapiclientutil = Resolve<INwsOpenApiClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
