using DeleteStuff.Core.Model.ConfigurationRepository.LoadOperation;
using DeleteStuff.Core.Model.ConfigurationRepository.LoadOperation.Stages;
using Moq;
using NUnit.Framework;
using SupaCharge.Core.IOAbstractions;

namespace DeleteStuff.UnitTests.Core.Model.ConfigurationRepository.LoadOperation.Stages {
  [TestFixture]
  public class LoadConfigurationFileStageTest : BaseTestCase {
    [Test]
    public void TestPriority() {
      Assert.That(mStage.Priority, Is.EqualTo(33));
    }

    [Test]
    public void TestExecuteLoadsConfigurationFile() {
      mFile.Setup(f => f.ReadAllText("deletestuff.json")).Returns("json");
      mStage.Execute(mContext, null);
      Assert.That(mContext.ConfigurationJson, Is.EqualTo("json"));
    }

    [SetUp]
    public void DoSetup() {
      mFile = Mok<IFile>();
      mStage = new LoadConfigurationFileStage(33, mFile.Object);
      mContext = CA<Context>();
      mContext.ConfigurationJson = null;
    }

    private Mock<IFile> mFile;
    private LoadConfigurationFileStage mStage;
    private Context mContext;
  }
}