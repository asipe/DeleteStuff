using Autofac;
using DeleteStuff.Core.Commands;
using DeleteStuff.Core.Commands.Config;

namespace DeleteStuff.Core.ObjectFactory.Module {
  public class ConfigCommandModule : BaseModule {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);

      builder
        .RegisterType<Command>()
        .InstancePerLifetimeScope()
        .Keyed<ICommand>("config");
    }
  }
}