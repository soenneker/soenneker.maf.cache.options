using Soenneker.Maf.Cache.Options.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Maf.Cache.Options.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class MafOptionsCacheTests : HostedUnitTest
{
    private readonly IMafOptionsCache _util;

    public MafOptionsCacheTests(Host host) : base(host)
    {
        _util = Resolve<IMafOptionsCache>(true);
    }

    [Test]
    public void Default()
    {

    }
}
