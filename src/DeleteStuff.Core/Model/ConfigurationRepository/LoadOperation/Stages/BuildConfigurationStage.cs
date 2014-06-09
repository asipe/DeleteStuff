using DeleteStuff.Core.Model.PathSpecificationBuilder;
using SupaCharge.Core.Patterns;

namespace DeleteStuff.Core.Model.ConfigurationRepository.LoadOperation.Stages {
  public class BuildConfigurationStage : Stage<Context> {
    public BuildConfigurationStage(int priority, IPathSpecificationBuilder builder) : base(priority) {
      mBuilder = builder;
    }

    protected override void DoExecute(Context context) {
      context.ExecutionConfiguration = BuildExecutionConfiguration(context);
    }

    private ExecutionConfiguration BuildExecutionConfiguration(Context context) {
      return new ExecutionConfiguration(mBuilder.Build(context.ExecutionConfigurationDTO));
    }

    private readonly IPathSpecificationBuilder mBuilder;
  }
}