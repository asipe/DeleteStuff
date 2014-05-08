using Autofac.Features.Indexed;
using DeleteStuff.Core.Command;

namespace DeleteStuff.Core.App {
  public class DeleteStuffApplication : IApplication {
    public DeleteStuffApplication(IIndex<string, ICommand> index) {
      mIndex = index;
    }

    public void Execute(params string[] args) {
      mIndex[args[0]].Execute(args);
    }

    private readonly IIndex<string, ICommand> mIndex;
  }
}