using System.Collections.Generic;
using System.Linq;
using DeleteStuff.Core.External;

namespace DeleteStuff.Core.Model.PathSpecificationBuilder {
  public class Builder : IPathSpecificationBuilder {
    public PathSpecification[] Build(ExecutionConfigurationDTO config) {
      return config
        .PathSpecifications
        .Select(BuildSpec)
        .ToArray();
    }

    private static string[] GetIncludes(PathSpecificationDTO specDTO) {
      return GetArrayOrEmpty(specDTO.Includes)
        .Distinct()
        .ToArray();
    }

    private static PathSpecification BuildSpec(PathSpecificationDTO specDTO) {
      return new PathSpecification(specDTO.Name, specDTO.BaseDirectory, GetIncludes(specDTO));
    }

    private static IEnumerable<string> GetArrayOrEmpty(string[] values) {
      return values ?? _Empty;
    }

    private static readonly string[] _Empty = new string[0];
  }
}