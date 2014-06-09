using DeleteStuff.Core.Commands.Config.List.Stages;
using DeleteStuff.Core.Model;
using DeleteStuff.Core.Model.ConfigurationRepository.LoadOperation;
using Moq;
using NUnit.Framework;
using Context = DeleteStuff.Core.Commands.Config.List.Context;

namespace DeleteStuff.UnitTests.Core.Commands.Config.List.Stages {
  [TestFixture]
  public class LoadConfigurationStageTest : BaseTestCase {
    [Test]
    public void TestPriority() {
      Assert.That(mStage.Priority, Is.EqualTo(33));
    }

    [Test]
    public void TestExecuteLoadsExecutionConfiguration() {
      var cfg = CA<ExecutionConfiguration>();
      mOperation.Setup(o => o.Load()).Returns(cfg);
      mStage.Execute(mContext);
      Assert.That(mContext.ExecutionConfiguration, Is.EqualTo(cfg));
    }

    [SetUp]
    public void DoSetup() {
      mOperation = Mok<ILoadOperation>();
      mStage = new LoadConfigurationStage(33, mOperation.Object);
      mContext = CA<Context>();
      mContext.ExecutionConfiguration = null;
    }

    private Mock<ILoadOperation> mOperation;
    private LoadConfigurationStage mStage;
    private Context mContext;
  }
}