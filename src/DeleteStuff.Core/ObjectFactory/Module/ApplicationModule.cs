using Autofac;
using DeleteStuff.Core.App;
using DeleteStuff.Core.Command;

namespace DeleteStuff.Core.ObjectFactory.Module {
  public class ApplicationModule : BaseModule {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);

      builder
        .RegisterType<DeleteStuffApplication>()
        .InstancePerLifetimeScope()
        .As<IApplication>();

      builder
        .RegisterType<CommandIndex>()
        .InstancePerLifetimeScope()
        .As<ICommandIndex>();
    }
  }
}