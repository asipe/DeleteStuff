using System.Collections.Generic;
using Autofac.Features.Indexed;

namespace DeleteStuff.Core.Command.Common {
  public class CommandIndex : ICommandIndex {
    public CommandIndex(IIndex<string, ICommand> index) {
      mIndex = index;
    }

    public ICommand GetCommand(params string[] args) {
      ValidateArgs(args, 1, "Missing Command");
      return TryGetCommand(args[0], args[0], "Unknown Command");
    }

    public ICommand GetSubcommand(params string[] args) {
      ValidateArgs(args, 2, "Missing Subcommand");
      return TryGetCommand(BuildSubcommandName(args), args[1], "Unknown Subcommand");
    }

    private ICommand TryGetCommand(string name, string arg, string message) {
      ICommand command;
      if (!mIndex.TryGetValue(name, out command))
        throw new DeleteStuffException("{0}: {1}", message, arg);
      return command;
    }

    private static void ValidateArgs(string[] args, int min, string message) {
      if (args.Length < min)
        throw new DeleteStuffException(message);
    }

    private static string BuildSubcommandName(IList<string> args) {
      return string.Format("{0}-{1}", args[0], args[1]);
    }

    private readonly IIndex<string, ICommand> mIndex;
  }
}