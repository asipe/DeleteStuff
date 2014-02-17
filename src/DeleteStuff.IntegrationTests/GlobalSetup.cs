using DeleteStuff.IntegrationTests.Infrastructure;
using NUnit.Framework;
using SupaCharge.Core.OID;

namespace DeleteStuff.IntegrationTests {
  [SetUpFixture]
  public sealed class GlobalSetup {
    [SetUp]
    public void DoSetup() {
      mTestEnvironment = new TestEnvironment(new PathInfo(new DevelopmentRoot().Get(), new GuidOIDProvider().GetID()));
      mTestEnvironment.Setup();
    }

    [TearDown]
    public void DoTearDown() {
      mTestEnvironment.TearDown();
    }

    private TestEnvironment mTestEnvironment;
  }
}