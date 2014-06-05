using DeleteStuff.Core.External;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.External {
  [TestFixture]
  public class ExecutionConfigurationDTOTest : BaseTestCase {
    [Test]
    public void TestDefaults() {
      var spec = new ExecutionConfigurationDTO();
      Assert.That(spec.PathSpecifications, Is.Null);
    }
  }
}