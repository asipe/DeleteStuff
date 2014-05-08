using DeleteStuff.Core.Utility;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.Utility {
  [TestFixture]
  public class JsonSerializerTest : BaseTestCase {
    internal sealed class Blah {
      public string Name{get;set;}
    }

    [Test]
    public void TestDeserialize() {
      Assert.That(new JsonSerializer().Deserialize<Blah>("{\"Name\": \"Bob\"}").Name, Is.EqualTo("Bob"));
    }
  }
}