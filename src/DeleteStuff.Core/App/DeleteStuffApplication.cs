using System;

namespace DeleteStuff.Core.App {
  public class DeleteStuffApplication : IApplication {
    public void Execute(params string[] args) {
      Console.Error.WriteLine("deletestuff.json could not be found");
      throw new DeleteStuffException("deletestuff.json could not be found");
    }
  }
}