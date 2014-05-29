namespace DeleteStuff.Core.Commands.Common {
  public interface ICommandIndex {
    ICommand GetCommand(params string[] args);
    ICommand GetSubcommand(params string[] args);
  }
}