﻿using DeleteStuff.Core.Commands.Stats.Stages;
using DeleteStuff.Core.Model;
using DeleteStuff.Core.Model.ConfigurationRepository.LoadPathSpecsOperation;
using Moq;
using NUnit.Framework;
using Context = DeleteStuff.Core.Commands.Stats.Context;

namespace DeleteStuff.UnitTests.Core.Commands.Stats.Stages {
  [TestFixture]
  public class LoadSpecsStageTest : BaseTestCase {
    [Test]
    public void TestPriority() {
      Assert.That(mStage.Priority, Is.EqualTo(33));
    }

    [Test]
    public void TestExecuteLoadsSpecsUsingOperation() {
      var specs = CM<PathSpecification>(1);
      mOperation.Setup(o => o.Load(mContext.Names)).Returns(specs);
      mStage.Execute(mContext);
      Assert.That(mContext.PathSpecifications, Is.EqualTo(specs));
    }

    [SetUp]
    public void DoSetup() {
      mOperation = Mok<ILoadPathSpecsOperation>();
      mStage = new LoadSpecsStage(33, mOperation.Object);
      mContext = CA<Context>();
      mContext.PathSpecifications = null;
    }

    private LoadSpecsStage mStage;
    private Context mContext;
    private Mock<ILoadPathSpecsOperation> mOperation;
  }
}