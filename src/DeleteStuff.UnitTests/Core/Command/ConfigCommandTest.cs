using Autofac.Features.Indexed;
using DeleteStuff.Core;
using DeleteStuff.Core.Command;
using Moq;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.Command {
  [TestFixture]
  public class ConfigCommandTest : BaseTestCase {
    [Test]
    public void TestExecuteBuildsSubCommandAndExecutes() {
      mIndex.Setup(i => i.TryGetValue("config-sub", out mCommand)).Returns(true);
      mMockCommand.Setup(c => c.Execute("config", "sub", "blah"));
      mCmd.Execute("config", "sub", "blah");
    }

    [Test]
    public void TestMissingSubcommandThrows() {
      var ex = Assert.Throws<DeleteStuffException>(() => mCmd.Execute("config"));
      Assert.That(ex.Message, Is.EqualTo("Missing Subcommand"));
    }

    [Test]
    public void TestUnknownSubcommandThrows() {
      mIndex.Setup(i => i.TryGetValue("config-blah", out mCommand)).Returns(false);
      var ex = Assert.Throws<DeleteStuffException>(() => mCmd.Execute("config", "blah"));
      Assert.That(ex.Message, Is.EqualTo("Unknown Subcommand: blah"));
    }

    [SetUp]
    public void DoSetup() {
      mMockCommand = Mok<ICommand>();
      mCommand = mMockCommand.Object;
      mIndex = Mok<IIndex<string, ICommand>>();
      mCmd = new ConfigCommand(mIndex.Object);
    }

    private ConfigCommand mCmd;
    private Mock<IIndex<string, ICommand>> mIndex;
    private Mock<ICommand> mMockCommand;
    private ICommand mCommand;
  }
}