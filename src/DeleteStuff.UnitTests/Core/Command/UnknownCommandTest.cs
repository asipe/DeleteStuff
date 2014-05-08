using DeleteStuff.Core;
using DeleteStuff.Core.Command;
using DeleteStuff.Core.Output;
using Moq;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.Command {
  [TestFixture]
  public class UnknownCommandTest : BaseTestCase {
    [Test]
    public void TestExecuteWithNoArgsNotifiesOnErrorAndThrows() {
      mObserver.Setup(o => o.OnError("Missing Command"));
      var ex = Assert.Throws<DeleteStuffException>(() => mCmd.Execute());
      Assert.That(ex.Message, Is.EqualTo("Missing Command"));
    }

    [Test]
    public void TestExecuteWithSingleArgNotifiesOnErrorAndThrows() {
      mObserver.Setup(o => o.OnError("Unknown Command: cmd1"));
      var ex = Assert.Throws<DeleteStuffException>(() => mCmd.Execute("cmd1"));
      Assert.That(ex.Message, Is.EqualTo("Unknown Command: cmd1"));
    }

    [Test]
    public void TestExecuteWithMultipleArgsNotifiesOnErrorAndThrows() {
      mObserver.Setup(o => o.OnError("Unknown Command: cmd1"));
      var ex = Assert.Throws<DeleteStuffException>(() => mCmd.Execute("cmd1", "blah", "blah"));
      Assert.That(ex.Message, Is.EqualTo("Unknown Command: cmd1"));
    }

    [SetUp]
    public void DoSetup() {
      mObserver = Mok<IObserver>();
      mCmd = new UnknownCommand(mObserver.Object);
    }

    private Mock<IObserver> mObserver;
    private UnknownCommand mCmd;
  }
}