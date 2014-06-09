namespace DeleteStuff.Core.Model {
  public class PathSpecification {
    public PathSpecification(string name, params string[] includes) {
      Name = name;
      Includes = includes;
    }

    public string Name{get;set;}
    public string[] Includes{get;set;}
  }
}