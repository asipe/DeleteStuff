using DeleteStuff.Core.Model;
using DeleteStuff.Core.Model.ConfigurationRepository.LoadOperation;
using Moq;
using NUnit.Framework;
using SupaCharge.Core.Patterns;

namespace DeleteStuff.UnitTests.Core.Model.ConfigurationRepository.LoadOperation {
  [TestFixture]
  public class OperationTest : BaseTestCase {
    [Test]
    public void TestExecuteDelegatesToPipeline() {
      var cfg = CA<ExecutionConfiguration>();
      mPipeline
        .Setup(p => p.Execute(Arg.Is(new Context())))
        .Callback<Context>(c => c.ExecutionConfiguration = cfg);
      Assert.That(mOperation.Load(), Is.EqualTo(cfg));
    }

    [SetUp]
    public void DoSetup() {
      mPipeline = Mok<IPipeline<Context>>();
      mOperation = new Operation(mPipeline.Object);
    }

    private Operation mOperation;
    private Mock<IPipeline<Context>> mPipeline;
  }
}