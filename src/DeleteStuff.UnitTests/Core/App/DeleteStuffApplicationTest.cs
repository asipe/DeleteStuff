using DeleteStuff.Core.App;
using DeleteStuff.Core.Command;
using DeleteStuff.Core.Commands;
using DeleteStuff.Core.Commands.Common;
using Moq;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.App {
  [TestFixture]
  public class DeleteStuffApplicationTest : BaseTestCase {
    [Test]
    public void TestExecute() {
      mIndex.Setup(i => i.GetCommand("config", "list")).Returns(mCommand.Object);
      mCommand.Setup(c => c.Execute("config", "list"));
      mApp.Execute("config", "list");
    }

    [SetUp]
    public void DoSetup() {
      mCommand = Mok<ICommand>();
      mIndex = Mok<ICommandIndex>();
      mApp = new DeleteStuffApplication(mIndex.Object);
    }

    private Mock<ICommandIndex> mIndex;
    private DeleteStuffApplication mApp;
    private Mock<ICommand> mCommand;
  }
}