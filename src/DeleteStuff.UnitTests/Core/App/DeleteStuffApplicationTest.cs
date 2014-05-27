using Autofac.Features.Indexed;
using DeleteStuff.Core.App;
using DeleteStuff.Core.Command;
using Moq;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.App {
  [TestFixture]
  public class DeleteStuffApplicationTest : BaseTestCase {
    [Test]
    public void TestExecute() {
      mIndex.Setup(i => i.TryGetValue("config", out mCommandImpl)).Returns(true);
      mCommand.Setup(c => c.Execute("config", "list"));
      mApp.Execute("config", "list");
    }

    [Test]
    public void TestExecuteWithNoCommandDelegatesToUnknownCommand() {
      mIndex.Setup(i => i.TryGetValue("unknown", out mCommandImpl)).Returns(true);
      mCommand.Setup(c => c.Execute());
      mApp.Execute();
    }

    [SetUp]
    public void DoSetup() {
      mCommand = Mok<ICommand>();
      mCommandImpl = mCommand.Object;
      mIndex = Mok<IIndex<string, ICommand>>();
      mApp = new DeleteStuffApplication(mIndex.Object);
    }

    private Mock<IIndex<string, ICommand>> mIndex;
    private DeleteStuffApplication mApp;
    private Mock<ICommand> mCommand;
    private ICommand mCommandImpl;
  }
}