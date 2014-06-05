using DeleteStuff.Core.External;

namespace DeleteStuff.Core.Model.ConfigurationRepository.LoadPathSpecsOperation {
  public class Context {
    public Context(params string[] names) {
      Names = names;
    }

    public string[] Names{get;set;}
    public PathSpecificationDTO[] PathSpecifications{get;set;}
    public ExecutionConfigurationDTO Configuration{get;set;}
  }
}