﻿using DeleteStuff.Core.Commands.Common;

namespace DeleteStuff.Core.Commands.Config {
  public class Command : ICommand {
    public Command(ICommandIndex index) {
      mIndex = index;
    }

    public void Execute(params string[] args) {
      mIndex.GetSubcommand(args).Execute(args);
    }

    private readonly ICommandIndex mIndex;
  }
}