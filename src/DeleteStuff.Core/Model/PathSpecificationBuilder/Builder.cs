using System.Collections.Generic;
using System.Linq;
using DeleteStuff.Core.External;

namespace DeleteStuff.Core.Model.PathSpecificationBuilder {
  public class Builder : IPathSpecificationBuilder {
    public PathSpecification[] Build(ExecutionConfigurationDTO config) {
      return config
        .PathSpecifications
        .Select(specDTO => BuildSpec(config.PathSpecifications, specDTO))
        .ToArray();
    }

    private static string[] GetIncludes(IEnumerable<PathSpecificationDTO> all, PathSpecificationDTO specDTO) {
      return GetArrayOrEmpty(specDTO.Includes)
        .Concat(GetIncludesForReferences(all, specDTO))
        .Distinct()
        .ToArray();
    }

    private static IEnumerable<string> GetIncludesForReferences(IEnumerable<PathSpecificationDTO> all, PathSpecificationDTO current) {
      return GetArrayOrEmpty(current.References)
        .Select(name => FindReferencedSpec(all, name))
        .SelectMany(specDTO => GetArrayOrEmpty(specDTO.Includes)
                                 .Concat(GetIncludesForReferences(all, specDTO)))
        .ToArray();
    }

    private static PathSpecificationDTO FindReferencedSpec(IEnumerable<PathSpecificationDTO> all, string name) {
      var specDTO = all.FirstOrDefault(s => s.Name == name);
      if (specDTO == null)
        throw new DeleteStuffException("Reference Not Found: {0}", name);
      return specDTO;
    }

    private static PathSpecification BuildSpec(IEnumerable<PathSpecificationDTO> all, PathSpecificationDTO specDTO) {
      return new PathSpecification(specDTO.Name, GetIncludes(all, specDTO));
    }

    private static IEnumerable<string> GetArrayOrEmpty(string[] values) {
      return values ?? _Empty;
    }

    private static readonly string[] _Empty = new string[0];
  }
}