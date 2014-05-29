using Autofac;
using DeleteStuff.Core.Command;

namespace DeleteStuff.Core.ObjectFactory.Module {
  public class UnknownCommandModule : BaseModule {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);

      builder
        .RegisterType<UnknownCommand>()
        .InstancePerLifetimeScope()
        .Keyed<ICommand>("unknown");
    }
  }
}