﻿using DeleteStuff.Core.Command;
using DeleteStuff.Core.Command.Common;

namespace DeleteStuff.Core.App {
  public class DeleteStuffApplication : IApplication {
    public DeleteStuffApplication(ICommandIndex index) {
      mIndex = index;
    }

    public void Execute(params string[] args) {
      mIndex.GetCommand(args).Execute(args);
    }

    private readonly ICommandIndex mIndex;
  }
}