using DeleteStuff.Core;
using DeleteStuff.Core.Command;
using DeleteStuff.Core.Output;
using Moq;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.Command {
  [TestFixture]
  public class ConfigListCommandTest : BaseTestCase {
    [Test]
    public void TestExecuteNotifiesAndThrows() {
      mObserver.Setup(o => o.OnError("deletestuff.json could not be found"));
      var ex = Assert.Throws<DeleteStuffException>(() => mCmd.Execute());
      Assert.That(ex.Message, Is.EqualTo("deletestuff.json could not be found"));
    }

    [SetUp]
    public void DoSetup() {
      mObserver = Mok<IObserver>();
      mCmd = new ConfigListCommand(mObserver.Object);
    }

    private Mock<IObserver> mObserver;
    private ConfigListCommand mCmd;
  }
}