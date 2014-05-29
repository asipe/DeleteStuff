using DeleteStuff.Core;
using DeleteStuff.Core.Command;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.Command {
  [TestFixture]
  public class UnknownCommandTest : BaseTestCase {
    [Test]
    public void TestExecuteWithNoArgsThrows() {
      var ex = Assert.Throws<DeleteStuffException>(() => mCmd.Execute());
      Assert.That(ex.Message, Is.EqualTo("Missing Command"));
    }

    [Test]
    public void TestExecuteWithSingleArgThrows() {
      var ex = Assert.Throws<DeleteStuffException>(() => mCmd.Execute("cmd1"));
      Assert.That(ex.Message, Is.EqualTo("Unknown Command: cmd1"));
    }

    [Test]
    public void TestExecuteWithMultipleArgsThrows() {
      var ex = Assert.Throws<DeleteStuffException>(() => mCmd.Execute("cmd1", "blah", "blah"));
      Assert.That(ex.Message, Is.EqualTo("Unknown Command: cmd1"));
    }

    [SetUp]
    public void DoSetup() {
      mCmd = new UnknownCommand();
    }

    private UnknownCommand mCmd;
  }
}