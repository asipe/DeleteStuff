using SupaCharge.Core.Patterns;

namespace DeleteStuff.Core.Model.ConfigurationRepository.LoadOperation {
  public class Operation : ILoadOperation {
    public Operation(IPipeline<Context> pipeline) {
      mPipeline = pipeline;
    }

    public ExecutionConfiguration Load() {
      var context = new Context();
      mPipeline.Execute(context);
      return context.ExecutionConfiguration;
    }

    private readonly IPipeline<Context> mPipeline;
  }
}