using DeleteStuff.Core.External;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.External {
  [TestFixture]
  public class PathSpecificationTest : BaseTestCase {
    [Test]
    public void TestDefaults() {
      var spec = new PathSpecification();
      Assert.That(spec.Name, Is.Null);
      Assert.That(spec.Includes, Is.Null);
      Assert.That(spec.References, Is.Null);
    }
  }
}