using DeleteStuff.IntegrationTests.Infrastructure;
using NUnit.Framework;

namespace DeleteStuff.IntegrationTests {
  [TestFixture]
  public abstract class BaseTest {
    [SetUp]
    public void DoSetup() {
      Helper.Setup();
    }

    [TestFixtureSetUp]
    public void DoFixtureSetup() {
      Helper = new DeleteStuffHelper();
    }

    protected DeleteStuffHelper Helper{get;private set;}
  }
}