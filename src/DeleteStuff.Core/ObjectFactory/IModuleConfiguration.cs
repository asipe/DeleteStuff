using Autofac;

namespace DeleteStuff.Core.ObjectFactory {
  public interface IModuleConfiguration {
    void Init(ContainerBuilder builder);
  }
}