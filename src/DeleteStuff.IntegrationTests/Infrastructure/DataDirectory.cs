using System;
using System.IO;

namespace DeleteStuff.IntegrationTests.Infrastructure {
  public class DataDirectory {
    public DataDirectory(PathInfo info) {
      mInfo = info;
    }

    public DataDirectory CreateDirectories(params string[] names) {
      Array.ForEach(names, name => Directory.CreateDirectory(GetDirectory(name)));
      return this;
    }

    public string GetDirectory(string name) {
      return Path.Combine(mInfo.TestDataDir, name);
    }

    public DataDirectory CreateFiles(params string[] names) {
      Array.ForEach(names, name => File.WriteAllText(Path.Combine(mInfo.TestDataDir, name), ""));
      return this;
    }

    private readonly PathInfo mInfo;
  }
}