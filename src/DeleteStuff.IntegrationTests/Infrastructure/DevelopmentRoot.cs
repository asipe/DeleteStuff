﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DeleteStuff.IntegrationTests.Infrastructure {
  public class DevelopmentRoot {
    public string Get() {
      return FindDevelopmentRoot(Directory.GetCurrentDirectory());
    }

    public string FindDevelopmentRoot(string dir) {
      return IsDevelopmentRoot(dir)
               ? dir
               : FindDevelopmentRoot(Path.GetDirectoryName(dir));
    }

    private static bool IsDevelopmentRoot(string dir) {
      return GetChecks(dir).All(f => f());
    }

    private static IEnumerable<Func<bool>> GetChecks(string dir) {
      yield return () => File.Exists(Path.Combine(dir, "README.md"));
      yield return () => File.Exists(Path.Combine(dir, "LICENSE"));
      yield return () => File.Exists(Path.Combine(dir, ".gitignore"));
      yield return () => Directory.Exists(Path.Combine(dir, "thirdparty"));
      yield return () => Directory.Exists(Path.Combine(dir, "scripts"));
      yield return () => Directory.Exists(Path.Combine(dir, "src"));
    }
  }
}