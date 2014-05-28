using DeleteStuff.Core.Command.ConfigList;
using DeleteStuff.Core.Command.ConfigList.Stages;
using DeleteStuff.Core.External;
using DeleteStuff.Core.Utility;
using Moq;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.Command.ConfigList.Stages {
  [TestFixture]
  public class DeserializeConfigurationStageTest : BaseTestCase {
    [Test]
    public void TestPriority() {
      Assert.That(mStage.Priority, Is.EqualTo(33));
    }

    [Test]
    public void TestExecuteDeserializesConfigurationJson() {
      var config = CA<ExecutionConfig>();
      mSerializer.Setup(s => s.Deserialize<ExecutionConfig>(mContext.ConfigurationJson)).Returns(config);
      mStage.Execute(mContext, null);
      Assert.That(mContext.ExecutionConfig, Is.EqualTo(config));
    }

    [SetUp]
    public void DoSetup() {
      mSerializer = Mok<ISerializer>();
      mStage = new DeserializeConfigurationStage(33, mSerializer.Object);
      mContext = CA<Context>();
      mContext.ExecutionConfig = null;
    }

    private Mock<ISerializer> mSerializer;
    private DeserializeConfigurationStage mStage;
    private Context mContext;
  }
}