using DeleteStuff.Core.External;
using DeleteStuff.Core.Model.ConfigurationRepository.LoadOperation;
using DeleteStuff.Core.Model.ConfigurationRepository.LoadSpecsOperation.Stages;
using Moq;
using NUnit.Framework;
using Context = DeleteStuff.Core.Model.ConfigurationRepository.LoadSpecsOperation.Context;

namespace DeleteStuff.UnitTests.Core.Model.ConfigurationRepository.LoadSpecsOperation.Stages {
  [TestFixture]
  public class LoadConfigurationStageTest : BaseTestCase {
    [Test]
    public void TestPriority() {
      Assert.That(mStage.Priority, Is.EqualTo(33));
    }

    [Test]
    public void TestExecuteLoadsConfiguration() {
      var cfg = CA<ExecutionConfig>();
      mLoadOperation.Setup(o => o.Load()).Returns(cfg);
      mStage.Execute(mContext, null);
      AssertAreEqual(mContext.Configuration, cfg);
    }

    [SetUp]
    public void DoSetup() {
      mLoadOperation = Mok<ILoadOperation>();
      mStage = new LoadConfigurationStage(33, mLoadOperation.Object);
      mContext = CA<Context>();
      mContext.Configuration = null;
    }

    private LoadConfigurationStage mStage;
    private Mock<ILoadOperation> mLoadOperation;
    private Context mContext;
  }
}