using DeleteStuff.Core.Model;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.Model {
  [TestFixture]
  public class ExecutionConfigurationTest : BaseTestCase {
    [Test]
    public void TestDefaults() {
      var specs = CM<PathSpecification>(0);
      var config = new ExecutionConfiguration(specs);
      Assert.That(config.PathSpecifications, Is.EqualTo(specs));
    }
  }
}