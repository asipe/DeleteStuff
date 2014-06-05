using DeleteStuff.Core.Commands.Config.List;
using DeleteStuff.Core.Commands.Config.List.Stages;
using DeleteStuff.Core.External;
using DeleteStuff.Core.Output;
using Moq;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.Commands.Config.List.Stages {
  [TestFixture]
  public class EchoConfigurationStageTest : BaseTestCase {
    [Test]
    public void TestPriority() {
      Assert.That(mStage.Priority, Is.EqualTo(33));
    }

    [Test]
    public void TestExecuteWithEmptyConfigEchosNothing() {
      mContext.ExecutionConfig.Specs = CM<PathSpec>(0);
      mStage.Execute(mContext, null);
    }

    [Test]
    public void TestExecuteWithSingleSpecEchos() {
      mContext.ExecutionConfig.Specs = CM<PathSpec>(1);
      mObserver.Setup(o => o.OnInfo(mContext.ExecutionConfig.Specs[0].Name));
      mObserver.Setup(o => o.OnInfo("   " + mContext.ExecutionConfig.Specs[0].Include[0]));
      mObserver.Setup(o => o.OnInfo("   " + mContext.ExecutionConfig.Specs[0].Include[1]));
      mObserver.Setup(o => o.OnInfo("   " + mContext.ExecutionConfig.Specs[0].Include[2]));
      mObserver.Setup(o => o.OnInfo(""));
      mStage.Execute(mContext, null);
    }

    [Test]
    public void TestExecuteWithMultipleSpecsEchos() {
      mContext.ExecutionConfig.Specs[0].Include = CM<string>(0);
      mContext.ExecutionConfig.Specs[1].Include = CM<string>(1);
      mObserver.Setup(o => o.OnInfo(mContext.ExecutionConfig.Specs[0].Name));
      mObserver.Setup(o => o.OnInfo(""));
      mObserver.Setup(o => o.OnInfo(mContext.ExecutionConfig.Specs[1].Name));
      mObserver.Setup(o => o.OnInfo("   " + mContext.ExecutionConfig.Specs[1].Include[0]));
      mObserver.Setup(o => o.OnInfo(""));
      mObserver.Setup(o => o.OnInfo(mContext.ExecutionConfig.Specs[2].Name));
      mObserver.Setup(o => o.OnInfo("   " + mContext.ExecutionConfig.Specs[2].Include[0]));
      mObserver.Setup(o => o.OnInfo("   " + mContext.ExecutionConfig.Specs[2].Include[1]));
      mObserver.Setup(o => o.OnInfo("   " + mContext.ExecutionConfig.Specs[2].Include[2]));
      mObserver.Setup(o => o.OnInfo(""));
      mStage.Execute(mContext, null);
    }

    [SetUp]
    public void DoSetup() {
      mObserver = Mok<IObserver>();
      mStage = new EchoConfigurationStage(33, mObserver.Object);
      mContext = CA<Context>();
    }

    private Mock<IObserver> mObserver;
    private EchoConfigurationStage mStage;
    private Context mContext;
  }
}