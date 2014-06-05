namespace DeleteStuff.Core.Model {
  public class PathSpecification {
    public PathSpecification(string name, string[] includes) {
      Name = name;
      Includes = includes;
    }

    public string Name{get;private set;}
    public string[] Includes{get;private set;}
  }
}