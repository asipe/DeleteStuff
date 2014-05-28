using DeleteStuff.Core.External;
using DeleteStuff.Core.Utility;
using SupaCharge.Core.Patterns;

namespace DeleteStuff.Core.Command.ConfigList.Stages {
  public class DeserializeConfigurationStage : Stage<Context> {
    public DeserializeConfigurationStage(int priority, ISerializer serializer) : base(priority) {
      mSerializer = serializer;
    }

    protected override void DoExecute(Context context) {
      context.ExecutionConfig = mSerializer.Deserialize<ExecutionConfig>(context.ConfigurationJson);
    }

    private readonly ISerializer mSerializer;
  }
}