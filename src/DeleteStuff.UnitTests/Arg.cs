using KellermanSoftware.CompareNetObjects;
using Moq;

namespace DeleteStuff.UnitTests {
  public static class Arg {
    public static T Is<T>(T expected) {
      return It.Is<T>(t => AreEqual(t, expected));
    }

    private static bool AreEqual(object actual, object expected) {
      return DoCompare(actual, expected).AreEqual;
    }

    private static ComparisonResult DoCompare(object actual, object expected) {
      return _ObjectComparer.Compare(actual, expected);
    }

    private static readonly CompareLogic _ObjectComparer = new CompareLogic();
  }
}