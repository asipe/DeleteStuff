using DeleteStuff.Core.External;
using DeleteStuff.Core.Model.ConfigurationRepository.LoadSpecsOperation;
using Moq;
using NUnit.Framework;
using SupaCharge.Core.Patterns;

namespace DeleteStuff.UnitTests.Core.Model.ConfigurationRepository.LoadSpecsOperation {
  [TestFixture]
  public class OperationTest : BaseTestCase {
    [Test]
    public void TestExecuteDelegatesToPipeline() {
      var specs = CM<PathSpec>(0);
      mPipeline
        .Setup(p => p.Execute(ItIs(new Context("A", "B"))))
        .Callback<Context>(c => c.PathSpecs = specs);
      Assert.That(mOperation.Load("A", "B"), Is.EqualTo(specs));
    }

    [SetUp]
    public void DoSetup() {
      mPipeline = Mok<IPipeline<Context>>();
      mOperation = new Operation(mPipeline.Object);
    }

    private Mock<IPipeline<Context>> mPipeline;
    private Operation mOperation;
  }
}