using DeleteStuff.Core.Command.ConfigList;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.Command.ConfigList {
  [TestFixture]
  public class ContextTest : BaseTestCase {
    [Test]
    public void TestDefaults() {
      var context = new Context();
      Assert.That(context.ConfigurationJson, Is.Null);
      Assert.That(context.ExecutionConfig, Is.Null);
    } 
  }
}