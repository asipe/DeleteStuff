using Autofac;

namespace DeleteStuff.Core.ObjectFactory.Module {
  public class DefaultModuleConfiguration : IModuleConfiguration {
    public void Init(ContainerBuilder builder) {
      builder.RegisterModule(new ApplicationModule());
      builder.RegisterModule(new OutputModule());
      builder.RegisterModule(new UnknownCommandModule());
      builder.RegisterModule(new ListConfigCommandModule());
      builder.RegisterModule(new ConfigCommandModule());
      builder.RegisterModule(new SerializerModule());
      builder.RegisterModule(new IOModule());
      builder.RegisterModule(new PipelineModule());
    }
  }
}