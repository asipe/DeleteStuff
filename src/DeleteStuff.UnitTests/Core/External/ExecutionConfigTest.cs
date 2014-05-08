using DeleteStuff.Core.External;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.External {
  [TestFixture]
  public class ExecutionConfigTest : BaseTestCase {
    [Test]
    public void TestDefaults() {
      var spec = new ExecutionConfig();
      Assert.That(spec.Specs, Is.Null);
    }
  }
}