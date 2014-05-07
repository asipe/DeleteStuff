using System;
using System.IO;
using Snarfz.Core;

namespace DeleteStuff.IntegrationTests.Infrastructure {
  public class TestEnvironment {
    public TestEnvironment(PathInfo info) {
      mInfo = info;
    }

    public void Setup() {
      Validate();
      CreateDirectories();
      CopyFiles();
    }

    public void TearDown() {
      if (Directory.Exists(mInfo.TestWorkingDir))
        Directory.Delete(mInfo.TestWorkingDir, true);
    }

    private void CopyFiles() {
      var cfg = new Config(mInfo.ConsoleDebugDir) {ScanType = ScanType.FilesOnly};
      cfg.OnFile += (s, a) => File.Copy(a.Path, Path.Combine(mInfo.TestWorkingDir, Path.GetFileName(a.Path)));
      Snarfzer.NewScanner().Start(cfg);
    }

    private void CreateDirectories() {
      if (!Directory.Exists(mInfo.TestRootDir))
        Directory.CreateDirectory(mInfo.TestRootDir);
      Directory.CreateDirectory(mInfo.TestWorkingDir);
    }

    private void Validate() {
      if (Directory.Exists(mInfo.TestWorkingDir))
        throw new Exception(string.Format("{0} already exists", mInfo.TestWorkingDir));
    }

    private readonly PathInfo mInfo;
  }
}