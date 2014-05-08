using Autofac.Features.Indexed;

namespace DeleteStuff.Core.Command {
  public class ConfigCommand : ICommand {
    public ConfigCommand(IIndex<string, ICommand> index) {
      mIndex = index;
    }

    public void Execute(params string[] args) {
      mIndex[string.Format("config-{0}", args[1])].Execute(args);
    }

    private readonly IIndex<string, ICommand> mIndex;
  }
}