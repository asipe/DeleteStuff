using Autofac;
using DeleteStuff.Core.Command;
using DeleteStuff.Core.Command.ConfigList;
using DeleteStuff.Core.Command.ConfigList.Stages;
using SupaCharge.Core.Patterns;

namespace DeleteStuff.Core.ObjectFactory.Module {
  public class ListConfigCommandModule : Autofac.Module {
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
      builder
        .RegisterType<ValidateConfigurationFileExistsStage>()
        .InstancePerLifetimeScope()
        .As<IStage<Context>>()
        .WithParameter("priority", 0);
    }
  }
}