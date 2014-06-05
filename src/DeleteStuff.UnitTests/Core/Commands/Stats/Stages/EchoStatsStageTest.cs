using DeleteStuff.Core.Commands.Stats;
using DeleteStuff.Core.Commands.Stats.Stages;
using DeleteStuff.Core.External;
using DeleteStuff.Core.Output;
using Moq;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.Commands.Stats.Stages {
  [TestFixture]
  public class EchoStatsStageTest : BaseTestCase {
    [Test]
    public void TestPriority() {
      Assert.That(mStage.Priority, Is.EqualTo(33));
    }

    [Test]
    public void TestExecuteWithNoSpecsEchosTotal() {
      mContext.PathSpecifications = CM<PathSpecification>(0);
      mObserver.Setup(o => o.OnInfo("total"));
      mObserver.Setup(o => o.OnInfo("   0 files"));
      mObserver.Setup(o => o.OnInfo("   0 bytes"));
      mObserver.Setup(o => o.OnInfo(""));
      mStage.Execute(mContext, null);
    }

    [Test]
    public void TestExecuteWithSingleSpecEchos() {
      mContext.PathSpecifications = CM<PathSpecification>(1);
      mObserver.Setup(o => o.OnInfo(mContext.PathSpecifications[0].Name));
      mObserver.Setup(o => o.OnInfo("   0 files"));
      mObserver.Setup(o => o.OnInfo("   0 bytes"));
      mObserver.Setup(o => o.OnInfo(""));
      mObserver.Setup(o => o.OnInfo("total"));
      mObserver.Setup(o => o.OnInfo("   0 files"));
      mObserver.Setup(o => o.OnInfo("   0 bytes"));
      mObserver.Setup(o => o.OnInfo(""));
      mStage.Execute(mContext, null);
    }

    [Test]
    public void TestExecuteWithMultipleSpecsEchos() {
      mObserver.Setup(o => o.OnInfo(mContext.PathSpecifications[0].Name));
      mObserver.Setup(o => o.OnInfo("   0 files"));
      mObserver.Setup(o => o.OnInfo("   0 bytes"));
      mObserver.Setup(o => o.OnInfo(""));
      mObserver.Setup(o => o.OnInfo(mContext.PathSpecifications[1].Name));
      mObserver.Setup(o => o.OnInfo("   0 files"));
      mObserver.Setup(o => o.OnInfo("   0 bytes"));
      mObserver.Setup(o => o.OnInfo(""));
      mObserver.Setup(o => o.OnInfo(mContext.PathSpecifications[2].Name));
      mObserver.Setup(o => o.OnInfo("   0 files"));
      mObserver.Setup(o => o.OnInfo("   0 bytes"));
      mObserver.Setup(o => o.OnInfo(""));
      mObserver.Setup(o => o.OnInfo("total"));
      mObserver.Setup(o => o.OnInfo("   0 files"));
      mObserver.Setup(o => o.OnInfo("   0 bytes"));
      mObserver.Setup(o => o.OnInfo(""));
      mStage.Execute(mContext, null);
    }

    [SetUp]
    public void DoSetup() {
      mObserver = Mok<IObserver>();
      mStage = new EchoStatsStage(33, mObserver.Object);
      mContext = CA<Context>();
    }

    private EchoStatsStage mStage;
    private Context mContext;
    private Mock<IObserver> mObserver;
  }
}