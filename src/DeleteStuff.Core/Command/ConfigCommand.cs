﻿namespace DeleteStuff.Core.Command {
  public class ConfigCommand : ICommand {
    public ConfigCommand(ICommandIndex index) {
      mIndex = index;
    }

    public void Execute(params string[] args) {
      mIndex.GetSubcommand(args).Execute(args);
    }

    private readonly ICommandIndex mIndex;
  }
}