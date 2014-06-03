using DeleteStuff.Core.External;

namespace DeleteStuff.Core.Model.ConfigurationRepository.LoadSpecsOperation {
  public interface ILoadSpecsOperation {
    PathSpec[] Load(params string[] names);
  }
}