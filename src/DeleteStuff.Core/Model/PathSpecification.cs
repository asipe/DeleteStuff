namespace DeleteStuff.Core.Model {
  public class PathSpecification {
    public PathSpecification(string name, string baseDirectory, params string[] includes) {
      Name = name;
      BaseDirectory = baseDirectory;
      Includes = includes;
    }

    public string Name{get;set;}
    public string BaseDirectory{get;set;}
    public string[] Includes{get;set;}
  }
}