namespace DeleteStuff.Core.Utility {
  public interface ISerializer {
    T Deserialize<T>(string json);
  }
}