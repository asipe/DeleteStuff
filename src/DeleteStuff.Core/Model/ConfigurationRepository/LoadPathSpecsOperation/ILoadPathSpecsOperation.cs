using DeleteStuff.Core.External;

namespace DeleteStuff.Core.Model.ConfigurationRepository.LoadPathSpecsOperation {
  public interface ILoadPathSpecsOperation {
    PathSpecification[] Load(params string[] names);
  }
}