using System.IO;

namespace DeleteStuff.IntegrationTests.Infrastructure {
  public class PathInfo {
    public PathInfo(string root, string id) {
      Root = root;
      DebugDir = Path.Combine(root, "Debug");
      ConsoleDebugDir = Path.Combine(DebugDir, @"net-4.5\DeleteStuff\");
      TestRootDir = Path.Combine(Root, @"integrationtestworking");
      TestWorkingDir = Path.Combine(TestRootDir, id);
      TestInstallDir = Path.Combine(TestWorkingDir, "install");
      ExePath = Path.Combine(TestInstallDir, "DeleteStuff.exe");
      JsonConfigPath = Path.Combine(TestInstallDir, "DeleteStuff.json");
      TestDataDir = Path.Combine(TestWorkingDir, "data");
    }

    public string TestDataDir{get;private set;}
    public string TestInstallDir{get;private set;}
    public string JsonConfigPath{get;private set;}
    public string ExePath{get;private set;}
    public string TestRootDir{get;private set;}
    public string Root{get;private set;}
    public string DebugDir{get;private set;}
    public string ConsoleDebugDir{get;private set;}
    public string TestWorkingDir{get;private set;}
  }
}