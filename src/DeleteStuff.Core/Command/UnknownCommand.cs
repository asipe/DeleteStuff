using System.Collections.Generic;
using DeleteStuff.Core.Output;

namespace DeleteStuff.Core.Command {
  public class UnknownCommand : ICommand {
    public UnknownCommand(IObserver observer) {
      mObserver = observer;
    }

    public void Execute(params string[] args) {
      NotifyAndThrow(BuildMessage(args));
    }

    private static string BuildMessage(IList<string> args) {
      return args.Count == 0
               ? "Missing Command"
               : string.Format("Unknown Command: {0}", args[0]);
    }

    private void NotifyAndThrow(string msg) {
      mObserver.OnError(msg);
      throw new DeleteStuffException(msg);
    }

    private readonly IObserver mObserver;
  }
}