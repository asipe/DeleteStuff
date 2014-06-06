using DeleteStuff.Core.Commands.Stats;
using DeleteStuff.Core.Commands.Stats.Stages;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.Commands.Stats.Stages {
  [TestFixture]
  public class ExtractNamesStageTest : BaseTestCase {
    [Test]
    public void TestPriority() {
      Assert.That(mStage.Priority, Is.EqualTo(33));
    }

    [TestCase(new string[0], new string[0])]
    [TestCase(new[] {"stats"}, new string[0])]
    [TestCase(new[] {"stats", "name0"}, new[] {"name0"})]
    [TestCase(new[] {"stats", "name0", "name1", "name2"}, new[] {"name0", "name1", "name2"})]
    public void TestExecuteExtractNamesFromArgs(string[] args, string[] expectedNames) {
      mContext.Args = args;
      mStage.Execute(mContext);
      Assert.That(mContext.Names, Is.EqualTo(expectedNames));
    }

    [SetUp]
    public void DoSetup() {
      mStage = new ExtractNamesStage(33);
      mContext = CA<Context>();
    }

    private ExtractNamesStage mStage;
    private Context mContext;
  }
}