using DeleteStuff.Core.Output;
using SupaCharge.Core.IOAbstractions;
using SupaCharge.Core.Patterns;

namespace DeleteStuff.Core.Command.ConfigList.Stages {
  public class ValidateConfigurationFileExistsStage : Stage<Context> {
    public ValidateConfigurationFileExistsStage(int priority, IObserver observer, IFile file) : base(priority) {
      mObserver = observer;
      mFile = file;
    }

    protected override void DoExecute(Context context) {
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