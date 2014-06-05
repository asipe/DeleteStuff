using DeleteStuff.Core.External;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.External {
  [TestFixture]
  public class ExecutionConfigurationTest : BaseTestCase {
    [Test]
    public void TestDefaults() {
      var spec = new ExecutionConfiguration();
      Assert.That(spec.PathSpecifications, Is.Null);
    }
  }
}