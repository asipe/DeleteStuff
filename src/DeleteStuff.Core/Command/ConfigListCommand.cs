using DeleteStuff.Core.Output;
using SupaCharge.Core.IOAbstractions;

namespace DeleteStuff.Core.Command {
  public class ConfigListCommand : ICommand {
    public ConfigListCommand(IObserver observer, IFile file) {
      mObserver = observer;
      mFile = file;
    }

    public void Execute(params string[] args) {
      if (!mFile.Exists("deletestuff.json"))
        NotifyAndThrow("deletestuff.json could not be found");
    }

    private void NotifyAndThrow(string msg) {
      mObserver.OnError(msg);
      throw new DeleteStuffException(msg);
    }

    private readonly IFile mFile;
    private readonly IObserver mObserver;
  }
}