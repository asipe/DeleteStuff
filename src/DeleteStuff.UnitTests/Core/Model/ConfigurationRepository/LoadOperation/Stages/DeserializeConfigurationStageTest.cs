using System;
using DeleteStuff.Core;
using DeleteStuff.Core.External;
using DeleteStuff.Core.Model.ConfigurationRepository.LoadOperation;
using DeleteStuff.Core.Model.ConfigurationRepository.LoadOperation.Stages;
using DeleteStuff.Core.Utility;
using Moq;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.Model.ConfigurationRepository.LoadOperation.Stages {
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

    [Test]
    public void TestDeserializeThrowsCapturesAndRethrows() {
      var exception = new Exception("test message");
      mSerializer.Setup(s => s.Deserialize<ExecutionConfig>(mContext.ConfigurationJson)).Throws(exception);
      var ex = Assert.Throws<DeleteStuffException>(() => mStage.Execute(mContext, null));
      Assert.That(ex.InnerException, Is.EqualTo(exception));
      Assert.That(ex.Message, Is.EqualTo("deletestuff.json does not contain valid json: test message"));
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