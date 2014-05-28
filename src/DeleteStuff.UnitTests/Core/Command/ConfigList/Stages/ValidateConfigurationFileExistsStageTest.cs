using DeleteStuff.Core;
using DeleteStuff.Core.Command.ConfigList;
using DeleteStuff.Core.Command.ConfigList.Stages;
using DeleteStuff.Core.Output;
using Moq;
using NUnit.Framework;
using SupaCharge.Core.IOAbstractions;

namespace DeleteStuff.UnitTests.Core.Command.ConfigList.Stages {
  [TestFixture]
  public class ValidateConfigurationFileExistsStageTest : BaseTestCase {
    [Test]
    public void TestPriority() {
      Assert.That(mStage.Priority, Is.EqualTo(33));
    }

    [Test]
    public void TestConfigurationFileExistsContinuesExecution() {
      mFile.Setup(f => f.Exists("deletestuff.json")).Returns(true);
      mStage.Execute(mContext, null);
    }

    [Test]
    public void TestConfigurationFileDoesNotExistNotifiesAndThrows() {
      mFile.Setup(f => f.Exists("deletestuff.json")).Returns(false);
      mObserver.Setup(o => o.OnError("deletestuff.json could not be found"));
      var ex = Assert.Throws<DeleteStuffException>(() => mStage.Execute(mContext, null));
      Assert.That(ex.Message, Is.EqualTo("deletestuff.json could not be found"));
    }

    [SetUp]
    public void DoSetup() {
      mFile = Mok<IFile>();
      mObserver = Mok<IObserver>();
      mStage = new ValidateConfigurationFileExistsStage(33, mObserver.Object, mFile.Object);
      mContext = CA<Context>();
    }

    private Mock<IFile> mFile;
    private Mock<IObserver> mObserver;
    private ValidateConfigurationFileExistsStage mStage;
    private Context mContext;
  }
}