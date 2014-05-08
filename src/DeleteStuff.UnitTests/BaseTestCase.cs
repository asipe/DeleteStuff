using Moq;
using NUnit.Framework;

namespace DeleteStuff.UnitTests {
  [TestFixture]
  public abstract class BaseTestCase {
    [SetUp]
    public void BaseSetup() {
      MokFac = new MockRepository(MockBehavior.Strict);
    }

    [TearDown]
    public void BaseTearDown() {
      VerifyMocks();
    }

    protected Mock<T> Mok<T>() where T : class {
      return MokFac.Create<T>();
    }

    private void VerifyMocks() {
      MokFac.VerifyAll();
    }

    protected MockRepository MokFac{get;private set;}
  }
}