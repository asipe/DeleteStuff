using Autofac;
using DeleteStuff.Core.Output;
using DeleteStuff.Core.Output.ConsoleOutput;

namespace DeleteStuff.Core.ObjectFactory.Module {
  public class OutputModule : BaseModule {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);

      builder
        .RegisterType<ConsoleWriter>()
        .InstancePerLifetimeScope()
        .As<IObserver>();
    }
  }
}