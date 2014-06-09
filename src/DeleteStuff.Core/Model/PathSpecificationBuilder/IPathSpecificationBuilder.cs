using DeleteStuff.Core.External;

namespace DeleteStuff.Core.Model.PathSpecificationBuilder {
  public interface IPathSpecificationBuilder {
    PathSpecification[] Build(ExecutionConfigurationDTO config);
  }
}