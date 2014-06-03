using System.Linq;
using SupaCharge.Core.Patterns;

namespace DeleteStuff.Core.Commands.Stats.Stages {
  public class ValidateNamesStage : Stage<Context> {
    public ValidateNamesStage(int priority) : base(priority) {}
    protected override void DoExecute(Context context) {
      if (!context.Names.Any())
        throw new DeleteStuffException("Missing Spec");
    }
  }
}