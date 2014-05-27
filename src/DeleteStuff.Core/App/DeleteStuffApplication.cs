using System.Collections.Generic;
using System.Linq;
using Autofac.Features.Indexed;
using DeleteStuff.Core.Command;

namespace DeleteStuff.Core.App {
  public class DeleteStuffApplication : IApplication {
    public DeleteStuffApplication(IIndex<string, ICommand> index) {
      mIndex = index;
    }

    public void Execute(params string[] args) {
      GetCommand(GetCommandName(args)).Execute(args);
    }

    private ICommand GetCommand(string commandName) {
      ICommand command;
      if (!mIndex.TryGetValue(commandName, out command))
        command = mIndex["unknown"];
      return command;
    }

    private static string GetCommandName(IList<string> args) {
      return args.Any()
               ? args[0]
               : "unknown";
    }

    private readonly IIndex<string, ICommand> mIndex;
  }
}