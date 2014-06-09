using DeleteStuff.Core.Model.ConfigurationRepository.LoadOperation;
using SupaCharge.Core.Patterns;

namespace DeleteStuff.Core.Model.ConfigurationRepository.LoadPathSpecsOperation.Stages {
  public class LoadConfigurationStage : Stage<Context> {
    public LoadConfigurationStage(int priority, ILoadOperation operation) : base(priority) {
      mOperation = operation;
    }

    protected override void DoExecute(Context context) {
      context.ExecutionConfiguration = mOperation.Load();
    }

    private readonly ILoadOperation mOperation;
  }
}