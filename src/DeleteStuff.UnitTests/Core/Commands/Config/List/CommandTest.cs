using DeleteStuff.Core.Commands.Config.List;
using Moq;
using NUnit.Framework;
using SupaCharge.Core.Patterns;

namespace DeleteStuff.UnitTests.Core.Commands.Config.List {
  [TestFixture]
  public class CommandTest : BaseTestCase {
    [Test]
    public void TestExecuteDelegatesToPipeline() {
      mPipeline.Setup(p => p.Execute(Arg.Is(new Context())));
      mCmd.Execute();
    }

    [SetUp]
    public void DoSetup() {
      mPipeline = Mok<IPipeline<Context>>();
      mCmd = new Command(mPipeline.Object);
    }

    private Command mCmd;
    private Mock<IPipeline<Context>> mPipeline;
  }
}