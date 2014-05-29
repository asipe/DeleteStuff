using System.Collections.Generic;
using Autofac.Features.Indexed;

namespace DeleteStuff.Core.Command {
  public class ConfigCommand : ICommand {
    public ConfigCommand(IIndex<string, ICommand> index) {
      mIndex = index;
    }

    public void Execute(params string[] args) {
      var subCommandName = GetSubCommand(args);
      ICommand subCommand;
      if (!mIndex.TryGetValue(subCommandName, out subCommand))
        throw new DeleteStuffException("Unknown Subcommand: {0}", args[1]);
      subCommand.Execute(args);
    }

    private static string GetSubCommand(IList<string> args) {
      if (args.Count < 2)
        throw new DeleteStuffException("Missing Subcommand");
      return string.Format("config-{0}", args[1]);
    }

    private readonly IIndex<string, ICommand> mIndex;
  }
}