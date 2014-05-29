using Autofac;
using SupaCharge.Core.Patterns;

namespace DeleteStuff.Core.ObjectFactory.Module {
  public abstract class BaseModule : Autofac.Module {
    protected static void RegisterStage<TStage, TContext>(ContainerBuilder builder, int priority) {
      builder
        .RegisterType<TStage>()
        .InstancePerLifetimeScope()
        .As<IStage<TContext>>()
        .WithParameter("priority", priority);
    }
  }
}