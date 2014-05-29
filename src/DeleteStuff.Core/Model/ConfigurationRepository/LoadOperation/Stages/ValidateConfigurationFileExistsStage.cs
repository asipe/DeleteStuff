using SupaCharge.Core.IOAbstractions;
using SupaCharge.Core.Patterns;

namespace DeleteStuff.Core.Model.ConfigurationRepository.LoadOperation.Stages {
  public class ValidateConfigurationFileExistsStage : Stage<Context> {
    public ValidateConfigurationFileExistsStage(int priority, IFile file) : base(priority) {
      mFile = file;
    }

    protected override void DoExecute(Context context) {
      if (!mFile.Exists("deletestuff.json"))
        throw new DeleteStuffException("deletestuff.json could not be found");
    }

    private readonly IFile mFile;
  }
}