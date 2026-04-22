using Soenneker.Tests.HostedUnit;

namespace Soenneker.Cohere.OpenApiClient.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class CohereOpenApiClientTests : HostedUnitTest
{
    public CohereOpenApiClientTests(Host host) : base(host)
    {
    }

    [Test]
    public void Default()
    {

    }
}
