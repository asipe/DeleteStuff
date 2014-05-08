using Autofac;
using DeleteStuff.Core.Utility;

namespace DeleteStuff.Core.ObjectFactory.Module {
  public class SerializerModule : Autofac.Module {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);

      builder
        .RegisterType<JsonSerializer>()
        .InstancePerLifetimeScope()
        .As<ISerializer>();
    }
  }
}