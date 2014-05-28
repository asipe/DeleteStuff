using DeleteStuff.Core.External;

namespace DeleteStuff.Core.Command.ConfigList {
  public class Context {
    public string ConfigurationJson{get;set;}
    public ExecutionConfig ExecutionConfig{get;set;}
  }
}