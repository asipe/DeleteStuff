using Autofac;
using DeleteStuff.Core.Commands;
using DeleteStuff.Core.Commands.Stats;
using DeleteStuff.Core.Commands.Stats.Stages;

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
      RegisterStage<ExtractNamesStage, Context>(builder, 0);
      RegisterStage<ValidateNamesStage, Context>(builder, 1);
    }
  }
}