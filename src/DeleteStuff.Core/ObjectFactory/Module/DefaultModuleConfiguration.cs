using Autofac;

namespace DeleteStuff.Core.ObjectFactory.Module {
  public class DefaultModuleConfiguration : IModuleConfiguration {
    public void Init(ContainerBuilder builder) {
      builder.RegisterModule(new ApplicationModule());
      builder.RegisterModule(new OutputModule());
    }
  }
}