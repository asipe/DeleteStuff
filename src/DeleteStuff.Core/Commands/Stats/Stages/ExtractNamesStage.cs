using System.Linq;
using SupaCharge.Core.Patterns;

namespace DeleteStuff.Core.Commands.Stats.Stages {
  public class ExtractNamesStage : Stage<Context> {
    public ExtractNamesStage(int priority) : base(priority) {}

    protected override void DoExecute(Context context) {
      context.Names = context
        .Args
        .Skip(1)
        .ToArray();
    }
  }
}