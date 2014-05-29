using Autofac.Features.Indexed;
using DeleteStuff.Core;
using DeleteStuff.Core.Command;
using Moq;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.App {
  [TestFixture]
  public class CommandIndexTest : BaseTestCase {
    [Test]
    public void TestGetCommandWhenCommandFoundReturnsCommand() {
      mIndex.Setup(i => i.TryGetValue("config", out mCommand)).Returns(true);
      Assert.That(mCommandIndex.GetCommand("config", "list"), Is.EqualTo(mCommand));
    }

    [Test]
    public void TestGetCommandWhenCommandIsMissingThrows() {
      var ex = Assert.Throws<DeleteStuffException>(() => mCommandIndex.GetCommand());
      Assert.That(ex.Message, Is.EqualTo("Missing Command"));
    }

    [Test]
    public void TestGetCommandWhenCommandIsUnknownThrows() {
      mIndex.Setup(i => i.TryGetValue("config", out mCommand)).Returns(false);
      var ex = Assert.Throws<DeleteStuffException>(() => mCommandIndex.GetCommand("config"));
      Assert.That(ex.Message, Is.EqualTo("Unknown Command: config"));
    }

    [Test]
    public void TestGetSubcommandWhenSubcommandFoundReturnsCommand() {
      mIndex.Setup(i => i.TryGetValue("config-list", out mCommand)).Returns(true);
      Assert.That(mCommandIndex.GetSubcommand("config", "list"), Is.EqualTo(mCommand));
    }

    [Test]
    public void TestGetSubcommandWhenSubcommandIsMissingThrows() {
      var ex = Assert.Throws<DeleteStuffException>(() => mCommandIndex.GetSubcommand("config"));
      Assert.That(ex.Message, Is.EqualTo("Missing Subcommand"));
    }

    [Test]
    public void TestGetSubcommandWhenSubcommandIsUnknownThrows() {
      mIndex.Setup(i => i.TryGetValue("config-list", out mCommand)).Returns(false);
      var ex = Assert.Throws<DeleteStuffException>(() => mCommandIndex.GetSubcommand("config", "list"));
      Assert.That(ex.Message, Is.EqualTo("Unknown Subcommand: list"));
    }

    [SetUp]
    public void DoSetup() {
      mMockCommand = Mok<ICommand>();
      mCommand = mMockCommand.Object;
      mIndex = Mok<IIndex<string, ICommand>>();
      mCommandIndex = new CommandIndex(mIndex.Object);
    }

    private Mock<IIndex<string, ICommand>> mIndex;
    private CommandIndex mCommandIndex;
    private Mock<ICommand> mMockCommand;
    private ICommand mCommand;
  }
}