using DeleteStuff.Core.Commands.Stats;
using Moq;
using NUnit.Framework;
using SupaCharge.Core.Patterns;

namespace DeleteStuff.UnitTests.Core.Commands.Stats {
  [TestFixture]
  public class CommandTest : BaseTestCase {
    [Test]
    public void TestExecuteDelegatesToPipeline() {
      mPipeline.Setup(p => p.Execute(ItIs(new Context())));
      mCommand.Execute();
    }

    [SetUp]
    public void DoSetup() {
      mPipeline = Mok<IPipeline<Context>>();
      mCommand = new Command(mPipeline.Object);
    }

    private Mock<IPipeline<Context>> mPipeline;
    private Command mCommand;
  }
}