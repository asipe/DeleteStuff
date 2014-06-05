using DeleteStuff.Core.External;
using SupaCharge.Core.Patterns;

namespace DeleteStuff.Core.Model.ConfigurationRepository.LoadPathSpecsOperation {
  public class Operation : ILoadPathSpecsOperation {
    public Operation(IPipeline<Context> pipeline) {
      mPipeline = pipeline;
    }

    public PathSpecificationDTO[] Load(params string[] names) {
      var context = new Context(names);
      mPipeline.Execute(context);
      return context.PathSpecifications;
    }

    private readonly IPipeline<Context> mPipeline;
  }
}