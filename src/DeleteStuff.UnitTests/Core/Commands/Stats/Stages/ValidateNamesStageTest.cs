using DeleteStuff.Core;
using DeleteStuff.Core.Commands.Stats;
using DeleteStuff.Core.Commands.Stats.Stages;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.Commands.Stats.Stages {
  [TestFixture]
  public class ValidateNamesStageTest : BaseTestCase {
    [Test]
    public void TestPriority() {
      Assert.That(mStage.Priority, Is.EqualTo(33));
    }

    [Test]
    public void TestExecuteWithMoreThanASingleNameDoesNotThrow() {
      mStage.Execute(mContext);
    }

    [Test]
    public void TestExecuteWithNoNamesThrows() {
      mContext.Names = BA<string>();
      var ex = Assert.Throws<DeleteStuffException>(() => mStage.Execute(mContext));
      Assert.That(ex.Message, Is.EqualTo("Missing Spec"));
    }

    [SetUp]
    public void DoSetup() {
      mStage = new ValidateNamesStage(33);
      mContext = CA<Context>();
    }

    private ValidateNamesStage mStage;
    private Context mContext;
  }
}