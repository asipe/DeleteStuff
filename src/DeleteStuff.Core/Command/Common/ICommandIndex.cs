namespace DeleteStuff.Core.Command.Common {
  public interface ICommandIndex {
    ICommand GetCommand(params string[] args);
    ICommand GetSubcommand(params string[] args);
  }
}