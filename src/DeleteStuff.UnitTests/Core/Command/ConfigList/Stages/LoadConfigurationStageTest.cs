using DeleteStuff.Core.Command.ConfigList.Stages;
using DeleteStuff.Core.External;
using DeleteStuff.Core.Model.ConfigurationRepository.LoadOperation;
using Moq;
using NUnit.Framework;
using Context = DeleteStuff.Core.Command.ConfigList.Context;

namespace DeleteStuff.UnitTests.Core.Command.ConfigList.Stages {
  [TestFixture]
  public class LoadConfigurationStageTest : BaseTestCase {
    [Test]
    public void TestPriority() {
      Assert.That(mStage.Priority, Is.EqualTo(33));
    }

    [Test]
    public void TestExecuteLoadsExecutionConfiguration() {
      var cfg = CA<ExecutionConfig>();
      mOperation.Setup(o => o.Load()).Returns(cfg);
      mStage.Execute(mContext, null);
      Assert.That(mContext.ExecutionConfig, Is.EqualTo(cfg));
    }

    [SetUp]
    public void DoSetup() {
      mOperation = Mok<ILoadOperation>();
      mStage = new LoadConfigurationStage(33, mOperation.Object);
      mContext = CA<Context>();
      mContext.ExecutionConfig = null;
    }

    private Mock<ILoadOperation> mOperation;
    private LoadConfigurationStage mStage;
    private Context mContext;
  }
}