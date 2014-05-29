using DeleteStuff.Core.Command;
using Moq;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.Command {
  [TestFixture]
  public class ConfigCommandTest : BaseTestCase {
    [Test]
    public void TestExecuteBuildsSubCommandAndExecutes() {
      mIndex.Setup(i => i.GetSubcommand("config", "sub", "blah")).Returns(mCommand.Object);
      mCommand.Setup(c => c.Execute("config", "sub", "blah"));
      mCmd.Execute("config", "sub", "blah");
    }

    [SetUp]
    public void DoSetup() {
      mCommand = Mok<ICommand>();
      mIndex = Mok<ICommandIndex>();
      mCmd = new ConfigCommand(mIndex.Object);
    }

    private ConfigCommand mCmd;
    private Mock<ICommandIndex> mIndex;
    private Mock<ICommand> mCommand;
  }
}