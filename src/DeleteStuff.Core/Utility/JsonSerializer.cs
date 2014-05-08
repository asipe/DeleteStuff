using Newtonsoft.Json;

namespace DeleteStuff.Core.Utility {
  public class JsonSerializer : ISerializer {
    public T Deserialize<T>(string json) {
      return JsonConvert.DeserializeObject<T>(json);
    }
  }
}