using System;

namespace DeleteStuff.Core.Output.ConsoleOutput {
  public class ConsoleWriter : IObserver {
    public void OnError(string msg) {
      Console.Error.WriteLine(msg);
    }
  }
}