using System.Collections.Generic;

namespace DeleteStuff.Core.Command {
  public class UnknownCommand : ICommand {
    public void Execute(params string[] args) {
      throw new DeleteStuffException(BuildMessage(args));
    }

    private static string BuildMessage(IList<string> args) {
      return args.Count == 0
               ? "Missing Command"
               : string.Format("Unknown Command: {0}", args[0]);
    }
  }
}