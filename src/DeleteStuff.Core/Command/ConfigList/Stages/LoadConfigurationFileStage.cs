using SupaCharge.Core.IOAbstractions;
using SupaCharge.Core.Patterns;

namespace DeleteStuff.Core.Command.ConfigList.Stages {
  public class LoadConfigurationFileStage : Stage<Context> {
    public LoadConfigurationFileStage(int priority, IFile file) : base(priority) {
      mFile = file;
    }

    protected override void DoExecute(Context context) {
      context.ConfigurationJson = mFile.ReadAllText("deletestuff.json");
    }

    private readonly IFile mFile;
  }
}