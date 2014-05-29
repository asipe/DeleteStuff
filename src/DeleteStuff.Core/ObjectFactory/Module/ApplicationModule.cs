using Autofac;
using DeleteStuff.Core.App;

namespace DeleteStuff.Core.ObjectFactory.Module {
  public class ApplicationModule : BaseModule {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);

      builder
        .RegisterType<DeleteStuffApplication>()
        .InstancePerLifetimeScope()
        .As<IApplication>();
    }
  }
}