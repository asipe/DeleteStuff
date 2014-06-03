using Autofac;
using DeleteStuff.Core.Commands;
using DeleteStuff.Core.Commands.Stats;

namespace DeleteStuff.Core.ObjectFactory.Module {
  public class StatsCommandModule : BaseModule {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);
      RegisterCommand(builder);
      RegisterStages(builder);
    }

    private static void RegisterCommand(ContainerBuilder builder) {
      builder
        .RegisterType<Command>()
        .InstancePerLifetimeScope()
        .Keyed<ICommand>("stats");
    }

    private static void RegisterStages(ContainerBuilder builder) {
      //RegisterStage<LoadConfigurationStage, dynamic>(builder, 0);
     // RegisterStage<EchoConfigurationStage, Context>(builder, 1);
    }
  }
}