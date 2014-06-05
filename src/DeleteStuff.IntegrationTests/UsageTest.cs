using DeleteStuff.Core.External;
using NUnit.Framework;

namespace DeleteStuff.IntegrationTests {
  [TestFixture]
  public class UsageTest : BaseTest {
    [Test]
    public void TestExecuteWithNoCommandGiven() {
      var result = Helper.ProcessExecutor.Start();
      Assert.That(result.ExitCode, Is.EqualTo(1));
      Assert.That(result.StandardOutput, Is.Empty);
      Assert.That(result.StandardError, Is.EqualTo(Helper.BuildOutput("Missing Command")));
    }

    [Test]
    public void TestExecuteWithUnknownCommand() {
      var result = Helper.ProcessExecutor.Start("cconfig");
      Assert.That(result.ExitCode, Is.EqualTo(1));
      Assert.That(result.StandardOutput, Is.Empty);
      Assert.That(result.StandardError, Is.EqualTo(Helper.BuildOutput("Unknown Command: cconfig")));
    }

    [Test]
    public void TestExecuteWithNoConfigSubCommand() {
      var result = Helper.ProcessExecutor.Start("config");
      Assert.That(result.ExitCode, Is.EqualTo(1));
      Assert.That(result.StandardOutput, Is.Empty);
      Assert.That(result.StandardError, Is.EqualTo(Helper.BuildOutput("Missing Subcommand")));
    }

    [Test]
    public void TestExecuteWithUnknownConfigSubCommand() {
      var result = Helper.ProcessExecutor.Start("config", "blah");
      Assert.That(result.ExitCode, Is.EqualTo(1));
      Assert.That(result.StandardOutput, Is.Empty);
      Assert.That(result.StandardError, Is.EqualTo(Helper.BuildOutput("Unknown Subcommand: blah")));
    }

    [Test]
    public void TestListConfigurationWhenNoConfigurationFileFound() {
      var result = Helper.ProcessExecutor.Start("config", "list");
      Assert.That(result.ExitCode, Is.EqualTo(1));
      Assert.That(result.StandardOutput, Is.Empty);
      Assert.That(result.StandardError, Is.EqualTo(Helper.BuildOutput("deletestuff.json could not be found")));
    }

    [TestCase("", "deletestuff.json does not contain a valid configuration: configuration is null")]
    [TestCase("  ", "deletestuff.json does not contain a valid configuration: configuration is null")]
    [TestCase("invalid json", "deletestuff.json does not contain valid json: Unexpected character encountered while parsing value: i. Path '', line 0, position 0.")]
    [TestCase("{}", "deletestuff.json does not contain a valid configuration: specs are null")]
    public void TestListConfigurationWhenMalformedConfigurationFile(string config, string expectedMessage) {
      Helper.WriteJsonConfig(config);
      var result = Helper.ProcessExecutor.Start("config", "list");
      Assert.That(result.ExitCode, Is.EqualTo(1));
      Assert.That(result.StandardOutput, Is.Empty);
      Assert.That(result.StandardError, Is.EqualTo(Helper.BuildOutput(expectedMessage)));
    }

    [Test]
    public void TestListConfigurationWhenNoPathSpecs() {
      Helper.WriteJsonConfig(new ExecutionConfig {Specs = new PathSpec[0]});
      var result = Helper.ProcessExecutor.Start("config", "list");
      Assert.That(result.ExitCode, Is.EqualTo(0));
      Assert.That(result.StandardOutput, Is.Empty);
      Assert.That(result.StandardError, Is.Empty);
    }

    [Test]
    public void TestListConfigurationWhenPathSpecs() {
      Helper.WriteJsonConfig(new ExecutionConfig {
                                                   Specs = new[] {
                                                                   new PathSpec {
                                                                                  Name = "project0",
                                                                                  Include = new string[0]
                                                                                },
                                                                   new PathSpec {
                                                                                  Name = "project1",
                                                                                  Include = new[] {@"c:\project1\bin\*.exe"}
                                                                                },
                                                                   new PathSpec {
                                                                                  Name = "project2",
                                                                                  Include = new[] {
                                                                                                    @"c:\project2\bin\*.exe",
                                                                                                    @"c:\project2\obj\*.dll"
                                                                                                  }
                                                                                },
                                                                   new PathSpec {
                                                                                  Name = "project3",
                                                                                  Include = new[] {
                                                                                                    @"c:\project3\bin\*.exe",
                                                                                                    @"c:\project3\obj\*.dll",
                                                                                                    @"c:\project3\app_data\**\*.*"
                                                                                                  }
                                                                                }
                                                                 }
                                                 });
      var result = Helper.ProcessExecutor.Start("config", "list");
      Assert.That(result.ExitCode, Is.EqualTo(0));
      Assert.That(result.StandardOutput, Is.EqualTo(Helper.BuildOutput("project0",
                                                                       "",
                                                                       "project1",
                                                                       @"   c:\project1\bin\*.exe",
                                                                       "",
                                                                       "project2",
                                                                       @"   c:\project2\bin\*.exe",
                                                                       @"   c:\project2\obj\*.dll",
                                                                       "",
                                                                       "project3",
                                                                       @"   c:\project3\bin\*.exe",
                                                                       @"   c:\project3\obj\*.dll",
                                                                       @"   c:\project3\app_data\**\*.*",
                                                                       "")));
      Assert.That(result.StandardError, Is.Empty);
    }

    [Test]
    public void TestStatsWithNoSpec() {
      Helper.WriteJsonConfig(new ExecutionConfig {Specs = new PathSpec[0]});
      var result = Helper.ProcessExecutor.Start("stats");
      Assert.That(result.ExitCode, Is.EqualTo(1));
      Assert.That(result.StandardOutput, Is.Empty);
      Assert.That(result.StandardError, Is.EqualTo(Helper.BuildOutput("Missing Spec")));
    }

    [Test]
    public void TestStatsWithUnknownSpec() {
      Helper.WriteJsonConfig(new ExecutionConfig {Specs = new PathSpec[0]});
      var result = Helper.ProcessExecutor.Start("stats", "project0");
      Assert.That(result.ExitCode, Is.EqualTo(1));
      Assert.That(result.StandardOutput, Is.Empty);
      Assert.That(result.StandardError, Is.EqualTo(Helper.BuildOutput("Unknown Spec: project0")));
    }

    [Test]
    public void TestStatsWithSingleSpecNoFiles() {
      Helper.DataDirectory.CreateDirectories("proj0");
      Helper.WriteJsonConfig(new ExecutionConfig {
                                                   Specs = new[] {
                                                                   new PathSpec {
                                                                                  Name = "project0",
                                                                                  Include = new[] {
                                                                                                    Helper.DataDirectory.GetDirectory("proj0")
                                                                                                  }
                                                                                }
                                                                 }
                                                 });
      var result = Helper.ProcessExecutor.Start("stats", "project0");
      Assert.That(result.ExitCode, Is.EqualTo(0));
      Assert.That(result.StandardOutput, Is.EqualTo(Helper.BuildOutput("project0",
                                                                       "   0 files",
                                                                       "   0 bytes",
                                                                       "",
                                                                       "total",
                                                                       "   0 files",
                                                                       "   0 bytes",
                                                                       "")));
      Assert.That(result.StandardError, Is.Empty);
    }

    [Test]
    public void TestStatsWithMultipleSpecsNoFiles() {
      Helper.DataDirectory.CreateDirectories("proj0", "proj1");
      Helper.WriteJsonConfig(new ExecutionConfig {
                                                   Specs = new[] {
                                                                   new PathSpec {
                                                                                  Name = "project0",
                                                                                  Include = new[] {
                                                                                                    Helper.DataDirectory.GetDirectory("proj0")
                                                                                                  }
                                                                                },
                                                                   new PathSpec {
                                                                                  Name = "project1",
                                                                                  Include = new[] {
                                                                                                    Helper.DataDirectory.GetDirectory("proj1")
                                                                                                  }
                                                                                }
                                                                 }
                                                 });
      var result = Helper.ProcessExecutor.Start("stats", "project0", "project1");
      Assert.That(result.ExitCode, Is.EqualTo(0));
      Assert.That(result.StandardOutput, Is.EqualTo(Helper.BuildOutput("project0",
                                                                       "   0 files",
                                                                       "   0 bytes",
                                                                       "",
                                                                       "project1",
                                                                       "   0 files",
                                                                       "   0 bytes",
                                                                       "",
                                                                       "total",
                                                                       "   0 files",
                                                                       "   0 bytes",
                                                                       "")));
      Assert.That(result.StandardError, Is.Empty);
    }
  }
}