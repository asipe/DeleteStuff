using System;
using DeleteStuff.Core.External;
using DeleteStuff.Core.Output;
using SupaCharge.Core.Patterns;

namespace DeleteStuff.Core.Commands.Config.List.Stages {
  public class EchoConfigurationStage : Stage<Context> {
    public EchoConfigurationStage(int priority, IObserver observer) : base(priority) {
      mObserver = observer;
    }

    protected override void DoExecute(Context context) {
      Array.ForEach(context.ExecutionConfiguration.PathSpecifications, EchoSpec);
    }

    private void EchoSpec(PathSpecificationDTO specification) {
      mObserver.OnInfo(specification.Name);
      Array.ForEach(specification.Includes, EchoEntry);
      mObserver.OnInfo("");
    }

    private void EchoEntry(string entry) {
      mObserver.OnInfo(string.Format("   {0}", entry));
    }

    private readonly IObserver mObserver;
  }
}