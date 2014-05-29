using Autofac;
using DeleteStuff.Core.Command;
using DeleteStuff.Core.Commands;
using DeleteStuff.Core.Commands.Config.List;
using DeleteStuff.Core.Commands.Config.List.Stages;

namespace DeleteStuff.Core.ObjectFactory.Module {
  public class ListConfigCommandModule : BaseModule {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);
      RegisterCommand(builder);
      RegisterStages(builder);
    }

    private static void RegisterCommand(ContainerBuilder builder) {
      builder
        .RegisterType<ConfigListCommand>()
        .InstancePerLifetimeScope()
        .Keyed<ICommand>("config-list");
    }

    private static void RegisterStages(ContainerBuilder builder) {
      RegisterStage<LoadConfigurationStage, Context>(builder, 0);
      RegisterStage<EchoConfigurationStage, Context>(builder, 1);
    }
  }
}