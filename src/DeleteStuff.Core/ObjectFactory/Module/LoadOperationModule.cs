using Autofac;
using DeleteStuff.Core.Model.ConfigurationRepository.LoadOperation;
using DeleteStuff.Core.Model.ConfigurationRepository.LoadOperation.Stages;

namespace DeleteStuff.Core.ObjectFactory.Module {
  public class LoadOperationModule : BaseModule {
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
      RegisterStage<ValidateConfigurationFileExistsStage, Context>(builder, 0);
      RegisterStage<LoadConfigurationFileStage, Context>(builder, 1);
      RegisterStage<DeserializeConfigurationStage, Context>(builder, 2);
      RegisterStage<ValidateConfigurationStage, Context>(builder, 3);
    }
  }
}