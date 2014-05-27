using Autofac;
using SupaCharge.Core.Patterns;

namespace DeleteStuff.Core.ObjectFactory.Module {
  public class PipelineModule : Autofac.Module {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);

      builder
        .RegisterGeneric(typeof(Pipeline<>))
        .InstancePerDependency()
        .As(typeof(IPipeline<>));
    }
  }
}