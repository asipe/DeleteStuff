using DeleteStuff.Core;
using DeleteStuff.Core.Model.ConfigurationRepository.LoadOperation;
using DeleteStuff.Core.Model.ConfigurationRepository.LoadOperation.Stages;
using Moq;
using NUnit.Framework;
using SupaCharge.Core.IOAbstractions;

namespace DeleteStuff.UnitTests.Core.Model.ConfigurationRepository.LoadOperation.Stages {
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
    public void TestConfigurationFileDoesNotExistThrows() {
      mFile.Setup(f => f.Exists("deletestuff.json")).Returns(false);
      var ex = Assert.Throws<DeleteStuffException>(() => mStage.Execute(mContext, null));
      Assert.That(ex.Message, Is.EqualTo("deletestuff.json could not be found"));
    }

    [SetUp]
    public void DoSetup() {
      mFile = Mok<IFile>();
      mStage = new ValidateConfigurationFileExistsStage(33, mFile.Object);
      mContext = CA<Context>();
    }

    private Mock<IFile> mFile;
    private ValidateConfigurationFileExistsStage mStage;
    private Context mContext;
  }
}