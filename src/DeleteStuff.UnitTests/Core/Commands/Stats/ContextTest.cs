using DeleteStuff.Core.Commands.Stats;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.Commands.Stats {
  [TestFixture]
  public class ContextTest : BaseTestCase {
    [Test]
    public void TestDefaults() {
      var context = new Context(BA("a", "b", "c"));
      Assert.That(context.Args, Is.EqualTo(BA("a", "b", "c")));
    }
  }
}