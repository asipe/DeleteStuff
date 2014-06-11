namespace DeleteStuff.Core.External {
  public class PathSpecificationDTO {
    public string Name{get;set;}
    public string BaseDirectory{get;set;}
    public string[] Includes{get;set;}
    public string[] References{get;set;}
  }
}