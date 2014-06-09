using DeleteStuff.Core;
using DeleteStuff.Core.Model.ConfigurationRepository.LoadOperation;
using DeleteStuff.Core.Model.ConfigurationRepository.LoadOperation.Stages;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.Model.ConfigurationRepository.LoadOperation.Stages {
  [TestFixture]
  public class ValidateConfigurationStageTest : BaseTestCase {
    [Test]
    public void TestPriority() {
      Assert.That(mStage.Priority, Is.EqualTo(33));
    }

    [Test]
    public void TestConfigurationIsValid() {
      mStage.Execute(mContext);
    }

    [Test]
    public void TestConfigurationIsNullThrows() {
      mContext.ExecutionConfigurationDTO = null;
      var ex = Assert.Throws<DeleteStuffException>(() => mStage.Execute(mContext));
      Assert.That(ex.Message, Is.EqualTo("deletestuff.json does not contain a valid configuration: configuration is null"));
    }

    [Test]
    public void TestConfigurationSpecsAreNull() {
      mContext.ExecutionConfigurationDTO.PathSpecifications = null;
      var ex = Assert.Throws<DeleteStuffException>(() => mStage.Execute(mContext));
      Assert.That(ex.Message, Is.EqualTo("deletestuff.json does not contain a valid configuration: specs are null"));
    }

    [SetUp]
    public void DoSetup() {
      mStage = new ValidateConfigurationStage(33);
      mContext = CA<Context>();
    }

    private ValidateConfigurationStage mStage;
    private Context mContext;
  }
}