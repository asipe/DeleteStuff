using System.Collections.Generic;
using System.Linq;
using SupaCharge.Core.Patterns;

namespace DeleteStuff.Core.Model.ConfigurationRepository.LoadPathSpecsOperation.Stages {
  public class FilterSpecsStage : Stage<Context> {
    public FilterSpecsStage(int priority) : base(priority) {}

    protected override void DoExecute(Context context) {
      context.PathSpecifications = FilterSpecs(context.ExecutionConfiguration.PathSpecifications, context.Names);
    }

    private static PathSpecification[] FilterSpecs(IEnumerable<PathSpecification> availableSpecs, IEnumerable<string> names) {
      return names
        .Select(name => FindSpec(availableSpecs, name))
        .ToArray();
    }

    private static PathSpecification FindSpec(IEnumerable<PathSpecification> availableSpecs, string name) {
      var spec = availableSpecs.FirstOrDefault(s => s.Name == name);
      if (spec == null)
        throw new DeleteStuffException("Unknown Spec: {0}", name);
      return spec;
    }
  }
}