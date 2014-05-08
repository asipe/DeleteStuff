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
      var cmd = Mok<ICommand>();
      mIndex.Setup(i => i["config"]).Returns(cmd.Object);
      cmd.Setup(c => c.Execute("config", "list"));
      mApp.Execute("config", "list");
    }

    [SetUp]
    public void DoSetup() {
      mIndex = Mok<IIndex<string, ICommand>>();
      mApp = new DeleteStuffApplication(mIndex.Object);
    }

    private Mock<IIndex<string, ICommand>> mIndex;
    private DeleteStuffApplication mApp;
  }
}