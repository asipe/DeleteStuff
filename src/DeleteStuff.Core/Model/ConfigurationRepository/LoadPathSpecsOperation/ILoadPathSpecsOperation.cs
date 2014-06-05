using DeleteStuff.Core.External;

namespace DeleteStuff.Core.Model.ConfigurationRepository.LoadPathSpecsOperation {
  public interface ILoadPathSpecsOperation {
    PathSpecificationDTO[] Load(params string[] names);
  }
}