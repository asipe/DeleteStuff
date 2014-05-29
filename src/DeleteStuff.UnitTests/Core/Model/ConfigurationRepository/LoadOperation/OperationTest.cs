using DeleteStuff.Core.External;
using DeleteStuff.Core.Model.ConfigurationRepository.LoadOperation;
using Moq;
using NUnit.Framework;
using SupaCharge.Core.Patterns;

namespace DeleteStuff.UnitTests.Core.Model.ConfigurationRepository.LoadOperation {
  [TestFixture]
  public class OperationTest : BaseTestCase {
    [Test]
    public void TestExecuteDelegatesToPipeline() {
      var cfg = CA<ExecutionConfig>();
      mPipeline
        .Setup(p => p.Execute(ItIs(new Context())))
        .Callback<Context>(c => c.ExecutionConfig = cfg);
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