namespace DeleteStuff.IntegrationTests.Infrastructure {
  public class ExecutionResult {
    public ExecutionResult(int exitCode, string standardOutput, string standardError) {
      StandardOutput = standardOutput;
      StandardError = standardError;
      ExitCode = exitCode;
    }

    public int ExitCode{get;private set;}
    public string StandardError{get;private set;}
    public string StandardOutput{get;private set;}
  }
}