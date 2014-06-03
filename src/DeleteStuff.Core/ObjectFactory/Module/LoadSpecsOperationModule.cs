using Autofac;
using DeleteStuff.Core.Model.ConfigurationRepository.LoadPathSpecsOperation;
using DeleteStuff.Core.Model.ConfigurationRepository.LoadPathSpecsOperation.Stages;

namespace DeleteStuff.Core.ObjectFactory.Module {
  public class LoadSpecsOperationModule : BaseModule {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);
      RegisterCommand(builder);
      RegisterStages(builder);
    }

    private static void RegisterCommand(ContainerBuilder builder) {
      builder
        .RegisterType<Operation>()
        .InstancePerLifetimeScope()
        .As<ILoadPathSpecsOperation>();
    }

    private static void RegisterStages(ContainerBuilder builder) {
      RegisterStage<LoadConfigurationStage, Context>(builder, 0);
      RegisterStage<FilterSpecsStage, Context>(builder, 1);
    }
  }
}