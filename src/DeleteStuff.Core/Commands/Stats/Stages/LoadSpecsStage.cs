using DeleteStuff.Core.Model.ConfigurationRepository.LoadSpecsOperation;
using SupaCharge.Core.Patterns;

namespace DeleteStuff.Core.Commands.Stats.Stages {
  public class LoadSpecsStage : Stage<Context> {
    public LoadSpecsStage(int priority, ILoadSpecsOperation operation) : base(priority) {
      mOperation = operation;
    }

    protected override void DoExecute(Context context) {
      context.PathSpecs = mOperation.Load(context.Names);
    }

    private readonly ILoadSpecsOperation mOperation;
  }
}