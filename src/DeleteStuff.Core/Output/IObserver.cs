namespace DeleteStuff.Core.Output {
  public interface IObserver {
    void OnError(string msg);
    void OnInfo(string msg);
  }
}