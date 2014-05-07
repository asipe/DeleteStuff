using NUnit.Framework;

namespace DeleteStuff.IntegrationTests {
  [TestFixture]
  public class UsageTest : BaseTest {
    [Test]
    public void TestListConfigurationWhenNoConfigurationFileFound() {
      var result = Helper.ProcessExecutor.Start("config", "list");
      Assert.That(result.ExitCode, Is.EqualTo(1));
      Assert.That(result.StandardOutput, Is.Empty);
      Assert.That(result.StandardError, Is.EqualTo("deletestuff.json could not be found\r\n"));
    }
  }
}