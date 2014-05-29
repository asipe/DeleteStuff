using System;
using DeleteStuff.Core.Output;
using SupaCharge.Core.Patterns;

namespace DeleteStuff.Core.Commands.Config.List.Stages {
  public class EchoConfigurationStage : Stage<Context> {
    public EchoConfigurationStage(int priority, IObserver observer) : base(priority) {
      mObserver = observer;
    }

    protected override void DoExecute(Context context) {
      Array.ForEach(context.ExecutionConfig.Specs, spec => mObserver.OnInfo(spec.Name));
    }

    private readonly IObserver mObserver;
  }
}