using Autofac;
using DeleteStuff.Core.Command;

namespace DeleteStuff.Core.ObjectFactory.Module {
  public class ConfigCommandModule : BaseModule {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);

      builder
        .RegisterType<ConfigCommand>()
        .InstancePerLifetimeScope()
        .Keyed<ICommand>("config");
    }
  }
}