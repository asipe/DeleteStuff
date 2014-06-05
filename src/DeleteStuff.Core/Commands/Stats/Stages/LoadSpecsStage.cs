using DeleteStuff.Core.Model.ConfigurationRepository.LoadPathSpecsOperation;
using SupaCharge.Core.Patterns;

namespace DeleteStuff.Core.Commands.Stats.Stages {
  public class LoadSpecsStage : Stage<Context> {
    public LoadSpecsStage(int priority, ILoadPathSpecsOperation operation) : base(priority) {
      mOperation = operation;
    }

    protected override void DoExecute(Context context) {
      context.PathSpecifications = mOperation.Load(context.Names);
    }

    private readonly ILoadPathSpecsOperation mOperation;
  }
}