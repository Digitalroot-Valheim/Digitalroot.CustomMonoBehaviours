using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

namespace Digitalroot.CustomMonoBehaviours
{
  /**
   * Copyright © Digitalroot Technologies 2021
   *
   * This program is free software: you can redistribute it and/or modify it under
   * the terms of the GNU Affero General Public License as published by the Free
   * Software Foundation, either version 3 of the License, or (at your option)
   * any later version.
   *
   * This program is distributed in the hope that it will be useful, but
   * WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY
   * or FITNESS FOR A PARTICULAR PURPOSE. See the GNU Affero General Public
   * License for more details.
   *
   * You should have received a copy of the GNU Affero General Public License
   * along with this program. If not, see https://www.gnu.org/licenses/
   */
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
    /// <param name="name">Name of the class.</param>
    /// <returns>Type of the class name passes.</returns>
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
