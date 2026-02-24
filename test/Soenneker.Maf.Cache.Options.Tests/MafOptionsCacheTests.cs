using Soenneker.Maf.Cache.Options.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Maf.Cache.Options.Tests;

[Collection("Collection")]
public sealed class MafOptionsCacheTests : FixturedUnitTest
{
    private readonly IMafOptionsCache _util;

    public MafOptionsCacheTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IMafOptionsCache>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
