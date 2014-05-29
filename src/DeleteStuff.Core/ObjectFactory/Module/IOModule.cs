using Autofac;
using SupaCharge.Core.IOAbstractions;

namespace DeleteStuff.Core.ObjectFactory.Module {
  public class IOModule : BaseModule {
    protected override void Load(ContainerBuilder builder) {
      base.Load(builder);

      builder
        .RegisterType<DotNetFile>()
        .SingleInstance()
        .As<IFile>();
    }
  }
}