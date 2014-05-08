namespace DeleteStuff.Core.Command {
  public interface ICommand {
    void Execute(params string[] args);
  }
}