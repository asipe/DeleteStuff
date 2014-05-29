using System;
using DeleteStuff.Core;
using DeleteStuff.Core.App;
using DeleteStuff.Core.ObjectFactory;
using DeleteStuff.Core.ObjectFactory.Module;

namespace DeleteStuff.Console {
  internal class Program {
    private static int Main(string[] args) {
      try {
        new Factory(new DefaultModuleConfiguration())
          .Build<IApplication>()
          .Execute(args);
        return 0;
      } catch (DeleteStuffException e) {
        System.Console.Error.WriteLine(e.Message);
        return 1;
      } catch (Exception e) {
        System.Console.Error.WriteLine(e.Message);
        return 1;
      }
    }
  }
}