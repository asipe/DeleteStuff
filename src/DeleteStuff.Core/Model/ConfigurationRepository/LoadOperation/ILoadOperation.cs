using DeleteStuff.Core.External;

namespace DeleteStuff.Core.Model.ConfigurationRepository.LoadOperation {
  public interface ILoadOperation {
    ExecutionConfig Load();
  }
}