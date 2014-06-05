using System;
using DeleteStuff.Core.External;
using DeleteStuff.Core.Output;
using SupaCharge.Core.Patterns;

namespace DeleteStuff.Core.Commands.Stats.Stages {
  public class EchoStatsStage : Stage<Context> {
    public EchoStatsStage(int priority, IObserver observer) : base(priority) {
      mObserver = observer;
    }

    protected override void DoExecute(Context context) {
      Array.ForEach(context.PathSpecifications, EchoSpec);
      Echo("total");
    }

    private void EchoSpec(PathSpecificationDTO specification) {
      Echo(specification.Name);
    }

    private void Echo(string name) {
      mObserver.OnInfo(name);
      mObserver.OnInfo("   0 files");
      mObserver.OnInfo("   0 bytes");
      mObserver.OnInfo("");
    }

    private readonly IObserver mObserver;
  }
}