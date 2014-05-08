using Autofac;
using DeleteStuff.Core.Command;

namespace DeleteStuff.Core.ObjectFactory.Module {
  public class ListConfigCommandModule : Autofac.Module {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);

      builder
        .RegisterType<ListConfigCommand>()
        .InstancePerLifetimeScope()
        .Keyed<ICommand>("config-list");
    }
  }
}