using System.IO;

namespace DeleteStuff.IntegrationTests.Infrastructure {
  public class PathInfo {
    public PathInfo(string root, string id) {
      Root = root;
      DebugDir = Path.Combine(root, "Debug");
      ConsoleDebugDir = Path.Combine(DebugDir, @"net-4.5\DeleteStuff\");
      TestRootDir = Path.Combine(Root, @"integrationtestworking");
      TestWorkingDir = Path.Combine(TestRootDir, id);
    }

    public string TestRootDir{get;private set;}
    public string Root{get;private set;}
    public string DebugDir{get;private set;}
    public string ConsoleDebugDir{get;private set;}
    public string TestWorkingDir{get;private set;}
  }
}