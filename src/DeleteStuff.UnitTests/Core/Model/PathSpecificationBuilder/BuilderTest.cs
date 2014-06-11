using DeleteStuff.Core.External;
using DeleteStuff.Core.Model;
using DeleteStuff.Core.Model.PathSpecificationBuilder;
using NUnit.Framework;

namespace DeleteStuff.UnitTests.Core.Model.PathSpecificationBuilder {
  [TestFixture]
  public class BuilderTest : BaseTestCase {
    [Test]
    public void TestEmptyConfigBuildsEmptySpecs() {
      mConfig.PathSpecifications = CM<PathSpecificationDTO>(0);
      Assert.That(mBuilder.Build(mConfig), Is.Empty);
    }

    [Test]
    public void TestConfigWithSingleSpecNoIncludesBuildsCorrectly() {
      mConfig.PathSpecifications = BA(new PathSpecificationDTO {
                                                                 Name = "proj0",
                                                                 BaseDirectory = "bdir0"
                                                               });
      AssertAreEqual(mBuilder.Build(mConfig), BA(new PathSpecification("proj0", "bdir0")));
    }

    [Test]
    public void TestConfigWithSingleSpecSingleIncludeBuildsCorrectly() {
      mConfig.PathSpecifications = BA(new PathSpecificationDTO {
                                                                 Name = "proj0",
                                                                 BaseDirectory = "bdir0",
                                                                 Includes = BA("inc-p0-0")
                                                               });
      AssertAreEqual(mBuilder.Build(mConfig), BA(new PathSpecification("proj0", "bdir0", "inc-p0-0")));
    }

    [Test]
    public void TestConfigMultipleSpecsSingleIncludeBuildsCorrectly() {
      mConfig.PathSpecifications = BA(new PathSpecificationDTO {
                                                                 Name = "proj0",
                                                                 BaseDirectory = "bdir0",
                                                                 Includes = BA("inc-p0-0")
                                                               },
                                      new PathSpecificationDTO {
                                                                 Name = "proj1",
                                                                 BaseDirectory = "bdir1",
                                                                 Includes = BA("inc-p1-0")
                                                               },
                                      new PathSpecificationDTO {
                                                                 Name = "proj2",
                                                                 BaseDirectory = "bdir2",
                                                                 Includes = BA("inc-p2-0")
                                                               });
      AssertAreEqual(mBuilder.Build(mConfig), BA(new PathSpecification("proj0", "bdir0", "inc-p0-0"),
                                                 new PathSpecification("proj1", "bdir1", "inc-p1-0"),
                                                 new PathSpecification("proj2", "bdir2", "inc-p2-0")));
    }

    [Test]
    public void TestConfigWithMultipleSpecsNoIncludesBuildsCorrectly() {
      mConfig.PathSpecifications = BA(new PathSpecificationDTO {
                                                                 Name = "proj0",
                                                                 BaseDirectory = "bdir0"
                                                               },
                                      new PathSpecificationDTO {
                                                                 Name = "proj1",
                                                                 BaseDirectory = "bdir1"
                                                               },
                                      new PathSpecificationDTO {
                                                                 Name = "proj2",
                                                                 BaseDirectory = "bdir2"
                                                               });
      AssertAreEqual(mBuilder.Build(mConfig), BA(new PathSpecification("proj0", "bdir0"),
                                                 new PathSpecification("proj1", "bdir1"),
                                                 new PathSpecification("proj2", "bdir2")));
    }

    [Test]
    public void TestDuplicateSpecIncludesAreRemoved() {
      mConfig.PathSpecifications = BA(new PathSpecificationDTO {
                                                                 Name = "proj0",
                                                                 BaseDirectory = "bdir0",
                                                                 Includes = BA("inc-p0-0", "inc-p0-1", "inc-p0-0")
                                                               },
                                      new PathSpecificationDTO {
                                                                 Name = "proj1",
                                                                 BaseDirectory = "bdir1",
                                                                 Includes = BA("inc-p1-0", "inc-p1-0", "inc-p1-0")
                                                               },
                                      new PathSpecificationDTO {
                                                                 Name = "proj2",
                                                                 BaseDirectory = "bdir2",
                                                                 Includes = BA("inc-p2-0", "inc-p2-1")
                                                               });
      AssertAreEqual(mBuilder.Build(mConfig), BA(new PathSpecification("proj0", "bdir0", "inc-p0-0", "inc-p0-1"),
                                                 new PathSpecification("proj1", "bdir1", "inc-p1-0"),
                                                 new PathSpecification("proj2", "bdir2", "inc-p2-0", "inc-p2-1")));
    }

    [SetUp]
    public void DoSetup() {
      mBuilder = new Builder();
      mConfig = CA<ExecutionConfigurationDTO>();
    }

    private Builder mBuilder;
    private ExecutionConfigurationDTO mConfig;
  }
}