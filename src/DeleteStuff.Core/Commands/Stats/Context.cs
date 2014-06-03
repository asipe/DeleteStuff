namespace DeleteStuff.Core.Commands.Stats {
  public class Context {
    public Context(params string[] args) {
      Args = args;
    }

    public string[] Args{get;private set;}
  }
}