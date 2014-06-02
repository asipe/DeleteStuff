using System;
using System.Diagnostics;
using NUnit.Framework;

namespace DeleteStuff.IntegrationTests.Infrastructure {
  public class ProcessExecutor {
    public ProcessExecutor(PathInfo pathInfo) {
      mPathInfo = pathInfo;
    }

    public ExecutionResult Start(params string[] args) {
      using (var process = Process.Start(new ProcessStartInfo {
                                                                WorkingDirectory = mPathInfo.TestInstallDir,
                                                                FileName = mPathInfo.ExePath,
                                                                UseShellExecute = false,
                                                                RedirectStandardError = true,
                                                                RedirectStandardOutput = true,
                                                                WindowStyle = ProcessWindowStyle.Hidden,
                                                                CreateNoWindow = true,
                                                                Arguments = CombineArgs(args)
                                                              })) {
        if (process == null)
          throw new Exception("Unable to start process");

        var standardError = process.StandardError.ReadToEnd();
        var standardOutput = process.StandardOutput.ReadToEnd();
        Assert.That(process.WaitForExit(60000 * 5), Is.True);
        return BuildResult(process, standardOutput, standardError);
      }
    }

    private static ExecutionResult BuildResult(Process process, string standardOutput, string standardError) {
      return new ExecutionResult(process.ExitCode, standardOutput, standardError);
    }

    private static string CombineArgs(string[] args) {
      return string.Join(" ", args);
    }

    private readonly PathInfo mPathInfo;
  }
}