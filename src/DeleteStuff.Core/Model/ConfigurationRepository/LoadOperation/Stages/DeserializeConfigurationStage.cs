using System;
using DeleteStuff.Core.External;
using DeleteStuff.Core.Utility;
using SupaCharge.Core.Patterns;

namespace DeleteStuff.Core.Model.ConfigurationRepository.LoadOperation.Stages {
  public class DeserializeConfigurationStage : Stage<Context> {
    public DeserializeConfigurationStage(int priority, ISerializer serializer) : base(priority) {
      mSerializer = serializer;
    }

    protected override void DoExecute(Context context) {
      try {
        context.ExecutionConfiguration = mSerializer.Deserialize<ExecutionConfiguration>(context.ConfigurationJson);
      } catch (Exception e) {
        throw new DeleteStuffException(string.Format("deletestuff.json does not contain valid json: {0}", e.Message), e);
      }
    }

    private readonly ISerializer mSerializer;
  }
}