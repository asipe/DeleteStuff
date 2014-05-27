﻿using SupaCharge.Core.Patterns;

namespace DeleteStuff.Core.Command.ConfigList {
  public class ConfigListCommand : ICommand {
    public ConfigListCommand(IPipeline<Context> pipeline) {
      mPipeline = pipeline;
    }

    public void Execute(params string[] args) {
      mPipeline.Execute(new Context());
    }

    private readonly IPipeline<Context> mPipeline;
  }
}