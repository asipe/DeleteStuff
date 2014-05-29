﻿using DeleteStuff.Core.External;
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
                                                                                  Name = "ps1",
                                                                                  Entries = new string[0]
                                                                                },
                                                                   new PathSpec {
                                                                                  Name = "ps2",
                                                                                  Entries = new string[0]
                                                                                },
                                                                   new PathSpec {
                                                                                  Name = "ps3",
                                                                                  Entries = new string[0]
                                                                                }
                                                                 }
                                                 });
      var result = Helper.ProcessExecutor.Start("config", "list");
      Assert.That(result.ExitCode, Is.EqualTo(0));
      Assert.That(result.StandardOutput, Is.EqualTo(Helper.BuildOutput("ps1", "ps2", "ps3")));
      Assert.That(result.StandardError, Is.Empty);
    }
  }
}