using DeleteStuff.Core.Commands.Stats.Stages;
using DeleteStuff.Core.External;
using DeleteStuff.Core.Model.ConfigurationRepository.LoadPathSpecsOperation;
using Moq;
using NUnit.Framework;
using Context = DeleteStuff.Core.Commands.Stats.Context;

namespace DeleteStuff.UnitTests.Core.Commands.Stats.Stages {
  [TestFixture]
  public class LoadSpecsStageTest : BaseTestCase {
    [Test]
    public void TestPriority() {
      Assert.That(mStage.Priority, Is.EqualTo(33));
    }

    [Test]
    public void TestExecuteLoadsSpecsUsingOperation() {
      var specs = CM<PathSpec>(1);
      mOperation.Setup(o => o.Load(mContext.Names)).Returns(specs);
      mStage.Execute(mContext, null);
      Assert.That(mContext.PathSpecs, Is.EqualTo(specs));
    }

    [SetUp]
    public void DoSetup() {
      mOperation = Mok<ILoadPathSpecsOperation>();
      mStage = new LoadSpecsStage(33, mOperation.Object);
      mContext = CA<Context>();
      mContext.PathSpecs = null;
    }

    private LoadSpecsStage mStage;
    private Context mContext;
    private Mock<ILoadPathSpecsOperation> mOperation;
  }
}