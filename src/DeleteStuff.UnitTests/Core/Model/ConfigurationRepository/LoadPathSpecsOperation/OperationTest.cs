using DeleteStuff.Core.Model;
using DeleteStuff.Core.Model.ConfigurationRepository.LoadPathSpecsOperation;
using Moq;
using NUnit.Framework;
using SupaCharge.Core.Patterns;

namespace DeleteStuff.UnitTests.Core.Model.ConfigurationRepository.LoadPathSpecsOperation {
  [TestFixture]
  public class OperationTest : BaseTestCase {
    [Test]
    public void TestExecuteDelegatesToPipeline() {
      var specs = CM<PathSpecification>(0);
      mPipeline
        .Setup(p => p.Execute(Arg.Is(new Context("A", "B"))))
        .Callback<Context>(c => c.PathSpecifications = specs);
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