using DeleteStuff.Core.External;
using SupaCharge.Core.Patterns;

namespace DeleteStuff.Core.Model.ConfigurationRepository.LoadOperation {
  public class Operation : ILoadOperation {
    public Operation(IPipeline<Context> pipeline) {
      mPipeline = pipeline;
    }

    public ExecutionConfig Load() {
      var context = new Context();
      mPipeline.Execute(context);
      return context.ExecutionConfig;
    }

    private readonly IPipeline<Context> mPipeline;
  }
}