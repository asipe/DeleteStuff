﻿using Moq;
using NUnit.Framework;
using Ploeh.AutoFixture;

namespace DeleteStuff.UnitTests {
  [TestFixture]
  public abstract class BaseTestCase {
    [SetUp]
    public void BaseSetup() {
      MokFac = new MockRepository(MockBehavior.Strict);
      ObjectFixture = new Fixture();
    }

    [TearDown]
    public void BaseTearDown() {
      VerifyMocks();
    }

    protected Mock<T> Mok<T>() where T : class {
      return MokFac.Create<T>();
    }

    protected T CA<T>() {
      return ObjectFixture.Create<T>();
    }

    protected Fixture ObjectFixture{get;set;}

    private void VerifyMocks() {
      MokFac.VerifyAll();
    }

    protected MockRepository MokFac{get;private set;}
  }
}