using System.Collections.Generic;
using System.Linq;
using DeleteStuff.Core.External;
using SupaCharge.Core.Patterns;

namespace DeleteStuff.Core.Model.ConfigurationRepository.LoadSpecsOperation.Stages {
  public class FilterSpecsStage : Stage<Context> {
    public FilterSpecsStage(int priority) : base(priority) {}

    protected override void DoExecute(Context context) {
      context.PathSpecs = FilterSpecs(context.Configuration.Specs, context.Names);
    }

    private static PathSpec[] FilterSpecs(IEnumerable<PathSpec> availableSpecs, IEnumerable<string> names) {
      return names
        .Select(name => FindSpec(availableSpecs, name))
        .ToArray();
    }

    private static PathSpec FindSpec(IEnumerable<PathSpec> availableSpecs, string name) {
      var spec = availableSpecs.FirstOrDefault(s => s.Name == name);
      if (spec == null)
        throw new DeleteStuffException("Unknown Spec: {0}", name);
      return spec;
    }
  }
}