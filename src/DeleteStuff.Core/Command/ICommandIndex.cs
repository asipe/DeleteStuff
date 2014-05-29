namespace DeleteStuff.Core.Command {
  public interface ICommandIndex {
    ICommand GetCommand(params string[] args);
    ICommand GetSubcommand(params string[] args);
  }
}