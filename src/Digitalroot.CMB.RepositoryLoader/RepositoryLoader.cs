using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Digitalroot.CustomMonoBehaviours
{
  [UsedImplicitly]
  public static class RepositoryLoader
  {
    /// <summary>
    /// Unique Collection of Custom Mono Behaviour Repositories
    /// </summary>
    private static readonly HashSet<Assembly> Assemblies = new();

    /// <summary>
    /// Name of the directory the DLL is in. 
    /// </summary>
    private static DirectoryInfo AssemblyDirectory
    {
      get
      {
        string codeBase = Assembly.GetExecutingAssembly().CodeBase;
        UriBuilder uri = new UriBuilder(codeBase);
        var fileInfo = new FileInfo(Uri.UnescapeDataString(uri.Path));
        return fileInfo.Directory;
      }
    }

    /// <summary>
    /// Gets a type from a loaded Assembly.
    /// Use LoadAssembly() to load your Custom Mono Behaviour Repositories first.
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    [UsedImplicitly]
    public static Type GetCustomMonoBehaviour(string name)
    {
      var type = Assembly.GetExecutingAssembly().GetType(name);

      if (type != null) return type;

      foreach (var assembly in Assemblies)
      {
        type = assembly.GetType(name);
        if (type != null)
        {
          return type;
        }
      }

      throw new ArgumentException($"Unable to find MonoBehaviour: {name}", nameof(name));
    }
    
    /// <summary>
    /// Load a Custom Mono Behaviour Repository
    /// </summary>
    /// <param name="pathToAssembly">Path to the assembly.</param>
    [UsedImplicitly]
    public static void LoadAssembly(string pathToAssembly)
    {
      LoadAssembly(new FileInfo(pathToAssembly));
    }

    /// <summary>
    /// Load a Custom Mono Behaviour Repository
    /// </summary>
    /// <param name="assemblyFileInfo">FileInfo object for the assembly.</param>
    // ReSharper disable once MemberCanBePrivate.Global
    public static void LoadAssembly(FileInfo assemblyFileInfo)
    {
      if (!assemblyFileInfo.Exists)
      {
        var localPath = Path.Combine(AssemblyDirectory.FullName, assemblyFileInfo.Name);
        if (!File.Exists(localPath))
        {
          throw new FileNotFoundException($"Unable to find {assemblyFileInfo.FullName}{Environment.NewLine} or {localPath}", assemblyFileInfo.FullName);
        }

        assemblyFileInfo = new FileInfo(localPath);
      }

      Assemblies.Add(Assembly.LoadFile(assemblyFileInfo.FullName));
    }
  }
}
