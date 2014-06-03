using DeleteStuff.Core.External;

namespace DeleteStuff.Core.Model.ConfigurationRepository.LoadSpecsOperation {
  public class Context {
    public Context(params string[] names) {
      Names = names;
    }

    public string[] Names{get;set;}
    public PathSpec[] Specs{get;set;}
    public ExecutionConfig Configuration{get;set;}
  }
}