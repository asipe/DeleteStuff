namespace DeleteStuff.IntegrationTests.Infrastructure {
  public class DeleteStuffHelper {
    public TestEnvironment TestEnvironment{get;private set;}
    public PathInfo PathInfo{get;private set;}
    public ProcessExecutor ProcessExecutor{get;private set;}

    public void Setup() {
      TestEnvironment = GlobalSetup.TestEnvironment;
      PathInfo = GlobalSetup.PathInfo;
      ProcessExecutor = new ProcessExecutor(PathInfo);
    }
  }
}