using Autofac;
using DeleteStuff.Core.Model.PathSpecificationBuilder;

namespace DeleteStuff.Core.ObjectFactory.Module {
  public class PathSpecificationBuilderModule : BaseModule {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);
      RegisterBuilder(builder);
    }

    private static void RegisterBuilder(ContainerBuilder builder) {
      builder
        .RegisterType<Builder>()
        .InstancePerLifetimeScope()
        .As<IPathSpecificationBuilder>();
    }
  }
}