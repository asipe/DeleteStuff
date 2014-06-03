using System;
using System.IO;
using DeleteStuff.Core.External;
using Newtonsoft.Json;

namespace DeleteStuff.IntegrationTests.Infrastructure {
  public class DeleteStuffHelper {
    public TestEnvironment TestEnvironment{get;private set;}
    public PathInfo PathInfo{get;private set;}
    public ProcessExecutor ProcessExecutor{get;private set;}
    public DataDirectory DataDirectory{get;private set;}

    public void Setup() {
      TestEnvironment = GlobalSetup.TestEnvironment;
      PathInfo = GlobalSetup.PathInfo;
      ProcessExecutor = new ProcessExecutor(PathInfo);
      DataDirectory = new DataDirectory(PathInfo);
      DeleteJsonConfig();
    }

    public void DeleteJsonConfig() {
      if (File.Exists(PathInfo.JsonConfigPath))
        File.Delete(PathInfo.JsonConfigPath);
    }

    public void WriteJsonConfig(ExecutionConfig config) {
      WriteJsonConfig(JsonConvert.SerializeObject(config));
    }

    public void WriteJsonConfig(string config) {
      File.WriteAllText(PathInfo.JsonConfigPath, config);
    }

    public string BuildOutput(params string[] lines) {
      return string.Join(Environment.NewLine, lines) + Environment.NewLine;
    }
  }
}