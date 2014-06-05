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
      mContext.ExecutionConfiguration.PathSpecifications = CM<PathSpecification>(0);
      mStage.Execute(mContext, null);
    }

    [Test]
    public void TestExecuteWithSingleSpecEchos() {
      mContext.ExecutionConfiguration.PathSpecifications = CM<PathSpecification>(1);
      mObserver.Setup(o => o.OnInfo(mContext.ExecutionConfiguration.PathSpecifications[0].Name));
      mObserver.Setup(o => o.OnInfo("   " + mContext.ExecutionConfiguration.PathSpecifications[0].Includes[0]));
      mObserver.Setup(o => o.OnInfo("   " + mContext.ExecutionConfiguration.PathSpecifications[0].Includes[1]));
      mObserver.Setup(o => o.OnInfo("   " + mContext.ExecutionConfiguration.PathSpecifications[0].Includes[2]));
      mObserver.Setup(o => o.OnInfo(""));
      mStage.Execute(mContext, null);
    }

    [Test]
    public void TestExecuteWithMultipleSpecsEchos() {
      mContext.ExecutionConfiguration.PathSpecifications[0].Includes = CM<string>(0);
      mContext.ExecutionConfiguration.PathSpecifications[1].Includes = CM<string>(1);
      mObserver.Setup(o => o.OnInfo(mContext.ExecutionConfiguration.PathSpecifications[0].Name));
      mObserver.Setup(o => o.OnInfo(""));
      mObserver.Setup(o => o.OnInfo(mContext.ExecutionConfiguration.PathSpecifications[1].Name));
      mObserver.Setup(o => o.OnInfo("   " + mContext.ExecutionConfiguration.PathSpecifications[1].Includes[0]));
      mObserver.Setup(o => o.OnInfo(""));
      mObserver.Setup(o => o.OnInfo(mContext.ExecutionConfiguration.PathSpecifications[2].Name));
      mObserver.Setup(o => o.OnInfo("   " + mContext.ExecutionConfiguration.PathSpecifications[2].Includes[0]));
      mObserver.Setup(o => o.OnInfo("   " + mContext.ExecutionConfiguration.PathSpecifications[2].Includes[1]));
      mObserver.Setup(o => o.OnInfo("   " + mContext.ExecutionConfiguration.PathSpecifications[2].Includes[2]));
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