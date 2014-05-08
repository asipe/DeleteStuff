using Autofac.Features.Indexed;
using DeleteStuff.Core.Command;
using Moq;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.Command {
  [TestFixture]
  public class ConfigCommandTest : BaseTestCase {
    [Test]
    public void TestExecuteBuildsSubCommandAndExecutes() {
      var subCommand = Mok<ICommand>();
      mIndex.Setup(i => i["config-sub"]).Returns(subCommand.Object);
      subCommand.Setup(c => c.Execute("config", "sub", "blah"));
      mCmd.Execute("config", "sub", "blah");
    }

    [SetUp]
    public void DoSetup() {
      mIndex = Mok<IIndex<string, ICommand>>();
      mCmd = new ConfigCommand(mIndex.Object);
    }

    private ConfigCommand mCmd;
    private Mock<IIndex<string, ICommand>> mIndex;
  }
}