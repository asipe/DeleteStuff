﻿using SupaCharge.Core.Patterns;

namespace DeleteStuff.Core.Commands.Stats {
  public class Command : ICommand {
    public Command(IPipeline<Context> pipeline) {
      mPipeline = pipeline;
    }

    public void Execute(params string[] args) {
      mPipeline.Execute(new Context(args));
    }

    private readonly IPipeline<Context> mPipeline;
  }
}