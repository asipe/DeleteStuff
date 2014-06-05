using DeleteStuff.Core.External;

namespace DeleteStuff.Core.Commands.Stats {
  public class Context {
    public Context(params string[] args) {
      Args = args;
    }

    public string[] Args{get;set;}
    public string[] Names{get;set;}
    public PathSpecificationDTO[] PathSpecifications{get;set;}
  }
}