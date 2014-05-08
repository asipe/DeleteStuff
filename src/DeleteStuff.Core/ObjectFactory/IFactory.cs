namespace DeleteStuff.Core.ObjectFactory {
  public interface IFactory {
    T Build<T>();
  }
}