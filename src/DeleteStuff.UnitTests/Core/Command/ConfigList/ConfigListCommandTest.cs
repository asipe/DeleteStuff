using DeleteStuff.Core.Command.ConfigList;
using Moq;
using NUnit.Framework;
using SupaCharge.Core.Patterns;

namespace DeleteStuff.UnitTests.Core.Command.ConfigList {
  [TestFixture]
  public class ConfigListCommandTest : BaseTestCase {
    [Test]
    public void TestExecuteDelegatesToPipeline() {
      mPipeline.Setup(p => p.Execute(It.Is<Context>(c => AreEqual(c, new Context()))));
      mCmd.Execute();
    }

    [SetUp]
    public void DoSetup() {
      mPipeline = Mok<IPipeline<Context>>();
      mCmd = new ConfigListCommand(mPipeline.Object);
    }

    private ConfigListCommand mCmd;
    private Mock<IPipeline<Context>> mPipeline;
  }
}