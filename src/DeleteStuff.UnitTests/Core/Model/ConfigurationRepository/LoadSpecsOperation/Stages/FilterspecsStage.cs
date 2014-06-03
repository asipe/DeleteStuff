using DeleteStuff.Core;
using DeleteStuff.Core.Model.ConfigurationRepository.LoadSpecsOperation;
using DeleteStuff.Core.Model.ConfigurationRepository.LoadSpecsOperation.Stages;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.Model.ConfigurationRepository.LoadSpecsOperation.Stages {
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
      Assert.That(mContext.PathSpecs, Is.Empty);
    }

    [Test]
    public void TestExecuteWithSingleSpecNameThatIsAvailableSetsSpecs() {
      mContext.Names = CM<string>(1);
      mContext.Configuration.Specs[0].Name = mContext.Names[0];
      mStage.Execute(mContext, null);
      AssertAreEqual(mContext.PathSpecs, BA(mContext.Configuration.Specs[0]));
    }

    [Test]
    public void TestExecuteWithMultipleSpecNamesThatareAvailableSetsSpecs() {
      mContext.Configuration.Specs[0].Name = mContext.Names[0];
      mContext.Configuration.Specs[1].Name = mContext.Names[1];
      mContext.Configuration.Specs[2].Name = mContext.Names[2];
      mStage.Execute(mContext, null);
      AssertAreEqual(mContext.PathSpecs, mContext.Configuration.Specs);
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
      mContext.PathSpecs = null;
    }

    private FilterSpecsStage mStage;
    private Context mContext;
  }
}