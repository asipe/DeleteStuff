using DeleteStuff.Core.External;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.External {
  [TestFixture]
  public class PathSpecTest : BaseTestCase {
    [Test]
    public void TestDefaults() {
      var spec = new PathSpec();
      Assert.That(spec.Name, Is.Null);
      Assert.That(spec.Include, Is.Null);
    }
  }
}