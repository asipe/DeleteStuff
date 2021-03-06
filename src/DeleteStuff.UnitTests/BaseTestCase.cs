﻿using System.Linq;
using KellermanSoftware.CompareNetObjects;
using Moq;
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

    protected T[] BA<T>(params T[] items) {
      return items;
    }

    protected T[] CM<T>(int count) {
      return (count == 0)
               ? BA<T>()
               : ObjectFixture
                   .CreateMany<T>(count)
                   .ToArray();
    }

    protected void AssertAreEqual(object actual, object expected) {
      var result = DoCompare(actual, expected);
      Assert.That(result.AreEqual, Is.True, result.DifferencesString);
    }

    protected static bool AreEqual(object actual, object expected) {
      return DoCompare(actual, expected).AreEqual;
    }

    private static ComparisonResult DoCompare(object actual, object expected) {
      return _ObjectComparer.Compare(actual, expected);
    }

    private void VerifyMocks() {
      MokFac.VerifyAll();
    }

    protected MockRepository MokFac{get;private set;}
    protected Fixture ObjectFixture{get;private set;}
    private static readonly CompareLogic _ObjectComparer = new CompareLogic();
  }
}