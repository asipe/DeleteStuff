using DeleteStuff.Core.Model;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.Model {
  [TestFixture]
  public class PathSpecificationTest : BaseTestCase {
    [Test]
    public void TestDefaults() {
      var spec = new PathSpecification("proj0", BA("1", "2"));
      Assert.That(spec.Name, Is.EqualTo("proj0"));
      Assert.That(spec.Includes, Is.EqualTo(BA("1", "2")));
    }
  }
}