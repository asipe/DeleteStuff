using Autofac;
using DeleteStuff.Core.Utility;

namespace DeleteStuff.Core.ObjectFactory.Module {
  public class SerializerModule : BaseModule {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);

      builder
        .RegisterType<JsonSerializer>()
        .InstancePerLifetimeScope()
        .As<ISerializer>();
    }
  }
}