namespace DeleteStuff.Core.Model {
  public class ExecutionConfiguration {
    public ExecutionConfiguration(PathSpecification[] pathSpecifications) {
      PathSpecifications = pathSpecifications;
    }

    public PathSpecification[] PathSpecifications{get;set;}
  }
}