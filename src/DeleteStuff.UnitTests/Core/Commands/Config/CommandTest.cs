using DeleteStuff.Core.Commands;
using DeleteStuff.Core.Commands.Common;
using DeleteStuff.Core.Commands.Config;
using Moq;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.Commands.Config {
  [TestFixture]
  public class CommandTest : BaseTestCase {
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
      mCmd = new Command(mIndex.Object);
    }

    private Command mCmd;
    private Mock<ICommandIndex> mIndex;
    private Mock<ICommand> mCommand;
  }
}