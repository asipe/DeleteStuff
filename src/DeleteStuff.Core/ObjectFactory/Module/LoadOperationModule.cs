using Autofac;
using DeleteStuff.Core.Model.ConfigurationRepository.LoadOperation;
using DeleteStuff.Core.Model.ConfigurationRepository.LoadOperation.Stages;
using SupaCharge.Core.Patterns;

namespace DeleteStuff.Core.ObjectFactory.Module {
  public class LoadOperationModule : Autofac.Module {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);
      RegisterOperation(builder);
      RegisterStages(builder);
    }

    private static void RegisterOperation(ContainerBuilder builder) {
      builder
        .RegisterType<Operation>()
        .InstancePerLifetimeScope()
        .As<ILoadOperation>();
    }

    private static void RegisterStages(ContainerBuilder builder) {
      RegisterStage<ValidateConfigurationFileExistsStage>(builder, 0);
      RegisterStage<LoadConfigurationFileStage>(builder, 1);
      RegisterStage<DeserializeConfigurationStage>(builder, 2);
    }

    private static void RegisterStage<T>(ContainerBuilder builder, int priority) {
      builder
        .RegisterType<T>()
        .InstancePerLifetimeScope()
        .As<IStage<Context>>()
        .WithParameter("priority", priority);
    }
  }
}