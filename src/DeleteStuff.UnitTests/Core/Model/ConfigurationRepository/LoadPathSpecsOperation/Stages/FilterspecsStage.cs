using DeleteStuff.Core;
using DeleteStuff.Core.Model.ConfigurationRepository.LoadPathSpecsOperation;
using DeleteStuff.Core.Model.ConfigurationRepository.LoadPathSpecsOperation.Stages;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.Model.ConfigurationRepository.LoadPathSpecsOperation.Stages {
  [TestFixture]
  public class FilterspecsStage : BaseTestCase {
    [Test]
    public void TestPriority() {
      Assert.That(mStage.Priority, Is.EqualTo(33));
    }

    [Test]
    public void TestExecuteWithNoSpecNamesSetsSpecsToEmpty() {
      mContext.Names = CM<string>(0);
      mStage.Execute(mContext, null);
      Assert.That(mContext.PathSpecifications, Is.Empty);
    }

    [Test]
    public void TestExecuteWithSingleSpecNameThatIsAvailableSetsSpecs() {
      mContext.Names = CM<string>(1);
      mContext.Configuration.PathSpecifications[0].Name = mContext.Names[0];
      mStage.Execute(mContext, null);
      AssertAreEqual(mContext.PathSpecifications, BA(mContext.Configuration.PathSpecifications[0]));
    }

    [Test]
    public void TestExecuteWithMultipleSpecNamesThatareAvailableSetsSpecs() {
      mContext.Configuration.PathSpecifications[0].Name = mContext.Names[0];
      mContext.Configuration.PathSpecifications[1].Name = mContext.Names[1];
      mContext.Configuration.PathSpecifications[2].Name = mContext.Names[2];
      mStage.Execute(mContext, null);
      AssertAreEqual(mContext.PathSpecifications, mContext.Configuration.PathSpecifications);
    }

    [Test]
    public void TestExecuteWithSpecNameThatIsNotFoundThrows() {
      mContext.Names[0] = "project0";
      var ex = Assert.Throws<DeleteStuffException>(() => mStage.Execute(mContext, null));
      Assert.That(ex.Message, Is.EqualTo("Unknown Spec: project0"));
    }

    [SetUp]
    public void DoSetup() {
      mStage = new FilterSpecsStage(33);
      mContext = CA<Context>();
      mContext.PathSpecifications = null;
    }

    private FilterSpecsStage mStage;
    private Context mContext;
  }
}