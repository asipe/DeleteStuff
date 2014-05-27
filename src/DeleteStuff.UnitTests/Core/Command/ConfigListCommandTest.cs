using DeleteStuff.Core;
using DeleteStuff.Core.Command;
using DeleteStuff.Core.Output;
using Moq;
using NUnit.Framework;
using SupaCharge.Core.IOAbstractions;

namespace DeleteStuff.UnitTests.Core.Command {
  [TestFixture]
  public class ConfigListCommandTest : BaseTestCase {
    [Test]
    public void TestConfigurationFileDoesNotExistNotifiesAndThrows() {
      mFile.Setup(f => f.Exists("deletestuff.json")).Returns(false);
      mObserver.Setup(o => o.OnError("deletestuff.json could not be found"));
      var ex = Assert.Throws<DeleteStuffException>(() => mCmd.Execute());
      Assert.That(ex.Message, Is.EqualTo("deletestuff.json could not be found"));
    }

    [Test]
    public void TestConfigurationFileExistDoesNothing() {
      mFile.Setup(f => f.Exists("deletestuff.json")).Returns(true);
      mCmd.Execute();
    }

    [SetUp]
    public void DoSetup() {
      mFile = Mok<IFile>();
      mObserver = Mok<IObserver>();
      mCmd = new ConfigListCommand(mObserver.Object, mFile.Object);
    }

    private Mock<IObserver> mObserver;
    private ConfigListCommand mCmd;
    private Mock<IFile> mFile;
  }
}