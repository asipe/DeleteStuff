using DeleteStuff.Core.Output;

namespace DeleteStuff.Core.Command {
  public class ListConfigCommand : ICommand {
    public ListConfigCommand(IObserver observer) {
      mObserver = observer;
    }

    public void Execute(params string[] args) {
      NotifyAndThrow("deletestuff.json could not be found");
    }

    private void NotifyAndThrow(string msg) {
      mObserver.OnError(msg);
      throw new DeleteStuffException(msg);
    }

    private readonly IObserver mObserver;
  }
}