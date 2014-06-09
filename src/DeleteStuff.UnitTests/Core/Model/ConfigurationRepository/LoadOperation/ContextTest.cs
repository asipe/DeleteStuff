using DeleteStuff.Core.Model.ConfigurationRepository.LoadOperation;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.Model.ConfigurationRepository.LoadOperation {
  [TestFixture]
  public class ContextTest : BaseTestCase {
    [Test]
    public void TestDefaults() {
      var context = new Context();
      Assert.That(context.ConfigurationJson, Is.Null);
      Assert.That(context.ExecutionConfiguration, Is.Null);
      Assert.That(context.ExecutionConfigurationDTO, Is.Null);
    }
  }
}