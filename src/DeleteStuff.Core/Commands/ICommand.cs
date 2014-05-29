namespace DeleteStuff.Core.Commands {
  public interface ICommand {
    void Execute(params string[] args);
  }
}