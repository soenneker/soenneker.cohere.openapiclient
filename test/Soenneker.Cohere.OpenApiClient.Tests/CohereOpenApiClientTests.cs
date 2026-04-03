using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Cohere.OpenApiClient.Tests;

[Collection("Collection")]
public sealed class CohereOpenApiClientTests : FixturedUnitTest
{
    public CohereOpenApiClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
    }

    [Fact]
    public void Default()
    {

    }
}
