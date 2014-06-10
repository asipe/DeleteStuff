using DeleteStuff.Core.External;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.External {
  [TestFixture]
  public class PathSpecificationDTOTest : BaseTestCase {
    [Test]
    public void TestDefaults() {
      var spec = new PathSpecificationDTO();
      Assert.That(spec.Name, Is.Null);
      Assert.That(spec.Includes, Is.Null);
      Assert.That(spec.References, Is.Null);
      Assert.That(spec.Includes, Is.Null);
    }
  }
}