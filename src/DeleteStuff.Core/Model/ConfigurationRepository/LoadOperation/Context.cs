using DeleteStuff.Core.External;

namespace DeleteStuff.Core.Model.ConfigurationRepository.LoadOperation {
  public class Context {
    public string ConfigurationJson{get;set;}
    public ExecutionConfigurationDTO ExecutionConfiguration{get;set;}
  }
}