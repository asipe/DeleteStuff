using DeleteStuff.Core.Model;
using DeleteStuff.Core.Model.ConfigurationRepository.LoadOperation;
using DeleteStuff.Core.Model.ConfigurationRepository.LoadOperation.Stages;
using DeleteStuff.Core.Model.PathSpecificationBuilder;
using Moq;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.Model.ConfigurationRepository.LoadOperation.Stages {
  [TestFixture]
  public class BuildConfigurationStageTest : BaseTestCase {
    [Test]
    public void TestPriority() {
      Assert.That(mStage.Priority, Is.EqualTo(33));
    }

    [Test]
    public void TestExecuteBuildsConfiguration() {
      var specs = BA<PathSpecification>();
      mBuilder.Setup(b => b.Build(mContext.ExecutionConfigurationDTO)).Returns(specs);
      mStage.Execute(mContext);
      AssertAreEqual(mContext.ExecutionConfiguration, new ExecutionConfiguration(specs));
    }

    [SetUp]
    public void DoSetup() {
      mBuilder = Mok<IPathSpecificationBuilder>();
      mStage = new BuildConfigurationStage(33, mBuilder.Object);
      mContext = CA<Context>();
      mContext.ExecutionConfiguration = null;
    }

    private BuildConfigurationStage mStage;
    private Context mContext;
    private Mock<IPathSpecificationBuilder> mBuilder;
  }
}