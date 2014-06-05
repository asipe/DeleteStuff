using SupaCharge.Core.Patterns;

namespace DeleteStuff.Core.Model.ConfigurationRepository.LoadOperation.Stages {
  public class ValidateConfigurationStage : Stage<Context> {
    public ValidateConfigurationStage(int priority) : base(priority) {}

    protected override void DoExecute(Context context) {
      Validate(context.ExecutionConfig, "configuration is null");
      Validate(context.ExecutionConfig.PathSpecifications, "specs are null");
    }

    private static void Validate(object obj, string msg) {
      if (obj == null)
        throw new DeleteStuffException("deletestuff.json does not contain a valid configuration: {0}", msg);
    }
  }
}