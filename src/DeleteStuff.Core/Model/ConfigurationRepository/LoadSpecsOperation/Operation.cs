using DeleteStuff.Core.External;
using SupaCharge.Core.Patterns;

namespace DeleteStuff.Core.Model.ConfigurationRepository.LoadSpecsOperation {
  public class Operation : ILoadSpecsOperation {
    public Operation(IPipeline<Context> pipeline) {
      mPipeline = pipeline;
    }

    public PathSpec[] Load(params string[] names) {
      var context = new Context(names);
      mPipeline.Execute(context);
      return context.PathSpecs;
    }

    private readonly IPipeline<Context> mPipeline;
  }
}