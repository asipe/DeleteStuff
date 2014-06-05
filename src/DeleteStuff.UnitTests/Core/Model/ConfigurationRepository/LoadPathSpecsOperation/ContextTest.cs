using DeleteStuff.Core.Model.ConfigurationRepository.LoadPathSpecsOperation;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.Model.ConfigurationRepository.LoadPathSpecsOperation {
  [TestFixture]
  public class ContextTest : BaseTestCase {
    [Test]
    public void TestDefaults() {
      var context = new Context("A", "B", "C");
      Assert.That(context.Names, Is.EqualTo(BA("A", "B", "C")));
      Assert.That(context.PathSpecifications, Is.Null);
      Assert.That(context.Configuration, Is.Null);
    }
  }
}