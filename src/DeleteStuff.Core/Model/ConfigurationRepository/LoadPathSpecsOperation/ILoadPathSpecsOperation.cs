using DeleteStuff.Core.External;

namespace DeleteStuff.Core.Model.ConfigurationRepository.LoadPathSpecsOperation {
  public interface ILoadPathSpecsOperation {
    PathSpec[] Load(params string[] names);
  }
}