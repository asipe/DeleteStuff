using DeleteStuff.Core.Output;

namespace DeleteStuff.Core.App {
  public class DeleteStuffApplication : IApplication {
    public DeleteStuffApplication(IObserver observer) {
      mObserver = observer;
    }

    public void Execute(params string[] args) {
      mObserver.OnError("deletestuff.json could not be found");
      throw new DeleteStuffException("deletestuff.json could not be found");
    }

    private readonly IObserver mObserver;
  }
}