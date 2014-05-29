using DeleteStuff.Core.Command.Config.List;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.Command.Config.List {
  [TestFixture]
  public class ContextTest : BaseTestCase {
    [Test]
    public void TestDefaults() {
      var context = new Context();
      Assert.That(context.ExecutionConfig, Is.Null);
    } 
  }
}