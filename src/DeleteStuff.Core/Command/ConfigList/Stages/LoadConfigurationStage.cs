using DeleteStuff.Core.Model.ConfigurationRepository.LoadOperation;
using SupaCharge.Core.Patterns;

namespace DeleteStuff.Core.Command.ConfigList.Stages {
  public class LoadConfigurationStage : Stage<Context> {
    public LoadConfigurationStage(int priority, ILoadOperation operation) : base(priority) {
      mOperation = operation;
    }

    protected override void DoExecute(Context context) {
      context.ExecutionConfig = mOperation.Load();
    }

    private readonly ILoadOperation mOperation;
  }
}