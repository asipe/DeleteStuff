using DeleteStuff.Core.Commands.Config.List;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.Commands.Config.List {
  [TestFixture]
  public class ContextTest : BaseTestCase {
    [Test]
    public void TestDefaults() {
      var context = new Context();
      Assert.That(context.ExecutionConfiguration, Is.Null);
    }
  }
}