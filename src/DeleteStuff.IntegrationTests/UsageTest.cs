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
      Helper.WriteJsonConfig(new ExecutionConfigurationDTO {PathSpecifications = new PathSpecificationDTO[0]});
      var result = Helper.ProcessExecutor.Start("config", "list");
      Assert.That(result.ExitCode, Is.EqualTo(0));
      Assert.That(result.StandardOutput, Is.Empty);
      Assert.That(result.StandardError, Is.Empty);
    }

    [Test]
    public void TestListConfigurationWhenPathSpecs() {
      Helper.WriteJsonConfig(new ExecutionConfigurationDTO {
                                                             PathSpecifications = new[] {
                                                                                          new PathSpecificationDTO {
                                                                                                                     Name = "project0",
                                                                                                                     BaseDirectory = "bdir0",
                                                                                                                     Includes = new string[0]
                                                                                                                   },
                                                                                          new PathSpecificationDTO {
                                                                                                                     Name = "project1",
                                                                                                                     BaseDirectory = "bdir1",
                                                                                                                     Includes = new[] {@"c:\project1\bin\*.exe"}
                                                                                                                   },
                                                                                          new PathSpecificationDTO {
                                                                                                                     Name = "project2",
                                                                                                                     BaseDirectory = "bdir2",
                                                                                                                     Includes = new[] {
                                                                                                                                        @"c:\project2\bin\*.exe",
                                                                                                                                        @"c:\project2\obj\*.dll"
                                                                                                                                      }
                                                                                                                   },
                                                                                          new PathSpecificationDTO {
                                                                                                                     Name = "project3",
                                                                                                                     BaseDirectory = "bdir3",
                                                                                                                     Includes = new[] {
                                                                                                                                        @"c:\project3\bin\*.exe",
                                                                                                                                        @"c:\project3\bin\*.exe",
                                                                                                                                        @"c:\project3\obj\*.dll",
                                                                                                                                        @"c:\project3\app_data\**\*.*",
                                                                                                                                        @"c:\project3\app_data\**\*.*"
                                                                                                                                      }
                                                                                                                   },
                                                                                          new PathSpecificationDTO {
                                                                                                                     Name = "project4",
                                                                                                                     BaseDirectory = "bdir4"
                                                                                                                   },
                                                                                          new PathSpecificationDTO {
                                                                                                                     Name = "project5",
                                                                                                                     BaseDirectory = "bdir5",
                                                                                                                     Includes = new string[0]
                                                                                                                   },
                                                                                          new PathSpecificationDTO {
                                                                                                                     Name = "project6",
                                                                                                                     BaseDirectory = "bdir6",
                                                                                                                     Includes = new[] {
                                                                                                                                        @"c:\project6\bin\*.exe",
                                                                                                                                        @"c:\project6\obj\*.dll",
                                                                                                                                        @"c:\project6\app_data\**\*.*",
                                                                                                                                        @"c:\project6\temp\*.*"
                                                                                                                                      }
                                                                                                                   },
                                                                                          new PathSpecificationDTO {
                                                                                                                     Name = "project7",
                                                                                                                     BaseDirectory = "bdir7",
                                                                                                                     Includes = new string[0]
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
                                                                       "",
                                                                       "project4",
                                                                       "",
                                                                       "project5",
                                                                       "",
                                                                       "project6",
                                                                       @"   c:\project6\bin\*.exe",
                                                                       @"   c:\project6\obj\*.dll",
                                                                       @"   c:\project6\app_data\**\*.*",
                                                                       @"   c:\project6\temp\*.*",
                                                                       "",
                                                                       "project7",
                                                                       "")));
      Assert.That(result.StandardError, Is.Empty);
    }

    [Test]
    public void TestStatsWithNoSpec() {
      Helper.WriteJsonConfig(new ExecutionConfigurationDTO {PathSpecifications = new PathSpecificationDTO[0]});
      var result = Helper.ProcessExecutor.Start("stats");
      Assert.That(result.ExitCode, Is.EqualTo(1));
      Assert.That(result.StandardOutput, Is.Empty);
      Assert.That(result.StandardError, Is.EqualTo(Helper.BuildOutput("Missing Spec")));
    }

    [Test]
    public void TestStatsWithUnknownSpec() {
      Helper.WriteJsonConfig(new ExecutionConfigurationDTO {PathSpecifications = new PathSpecificationDTO[0]});
      var result = Helper.ProcessExecutor.Start("stats", "project0");
      Assert.That(result.ExitCode, Is.EqualTo(1));
      Assert.That(result.StandardOutput, Is.Empty);
      Assert.That(result.StandardError, Is.EqualTo(Helper.BuildOutput("Unknown Spec: project0")));
    }

    [Test]
    public void TestStatsWithSingleSpecNoFiles() {
      Helper.DataDirectory.CreateDirectories("proj0");
      Helper.WriteJsonConfig(new ExecutionConfigurationDTO {
                                                             PathSpecifications = new[] {
                                                                                          new PathSpecificationDTO {
                                                                                                                     Name = "project0",
                                                                                                                     BaseDirectory = "bdir0",
                                                                                                                     Includes = new[] {
                                                                                                                                        Helper.DataDirectory.GetDirectory(@"proj0\*.*")
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
      Helper.WriteJsonConfig(new ExecutionConfigurationDTO {
                                                             PathSpecifications = new[] {
                                                                                          new PathSpecificationDTO {
                                                                                                                     Name = "project0",
                                                                                                                     BaseDirectory = "bdir0",
                                                                                                                     Includes = new[] {
                                                                                                                                        Helper.DataDirectory.GetDirectory(@"proj0\*.*")
                                                                                                                                      }
                                                                                                                   },
                                                                                          new PathSpecificationDTO {
                                                                                                                     Name = "project1",
                                                                                                                     BaseDirectory = "bdir1",
                                                                                                                     Includes = new[] {
                                                                                                                                        Helper.DataDirectory.GetDirectory(@"proj1\*.*")
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

    [Test]
    [Ignore("In Progress")]
    public void TestStatsWithMultipleSpecsWithFiles() {
      Helper.DataDirectory.CreateDirectories("proj0", "proj1");
      Helper.DataDirectory.CreateFiles(@"proj0\proj0-file1.txt");
      Helper.DataDirectory.CreateFiles(@"proj1\proj1-file1.txt");
      Helper.WriteJsonConfig(new ExecutionConfigurationDTO {
                                                             PathSpecifications = new[] {
                                                                                          new PathSpecificationDTO {
                                                                                                                     Name = "project0",
                                                                                                                     BaseDirectory = "bdir0",
                                                                                                                     Includes = new[] {
                                                                                                                                        Helper.DataDirectory.GetDirectory(@"proj0\*.*")
                                                                                                                                      }
                                                                                                                   },
                                                                                          new PathSpecificationDTO {
                                                                                                                     Name = "project1",
                                                                                                                     BaseDirectory = "bdir1",
                                                                                                                     Includes = new[] {
                                                                                                                                        Helper.DataDirectory.GetDirectory(@"proj1\*.*")
                                                                                                                                      }
                                                                                                                   }
                                                                                        }
                                                           });
      var result = Helper.ProcessExecutor.Start("stats", "project0", "project1");
      Assert.That(result.ExitCode, Is.EqualTo(0));
      Assert.That(result.StandardOutput, Is.EqualTo(Helper.BuildOutput("project0",
                                                                       "   1 files",
                                                                       "   0 bytes",
                                                                       "",
                                                                       "project1",
                                                                       "   1 files",
                                                                       "   0 bytes",
                                                                       "",
                                                                       "total",
                                                                       "   1 files",
                                                                       "   0 bytes",
                                                                       "")));
      Assert.That(result.StandardError, Is.Empty);
    }
  }
}