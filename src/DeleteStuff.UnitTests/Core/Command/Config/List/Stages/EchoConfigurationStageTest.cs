using DeleteStuff.Core.Command.Config.List;
using DeleteStuff.Core.Command.Config.List.Stages;
using DeleteStuff.Core.External;
using DeleteStuff.Core.Output;
using Moq;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.Command.Config.List.Stages {
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
      mStage.Execute(mContext, null);
    }

    [Test]
    public void TestExecuteWithMultipleSpecsEchos() {
      mObserver.Setup(o => o.OnInfo(mContext.ExecutionConfig.Specs[0].Name));
      mObserver.Setup(o => o.OnInfo(mContext.ExecutionConfig.Specs[1].Name));
      mObserver.Setup(o => o.OnInfo(mContext.ExecutionConfig.Specs[2].Name));
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