﻿## MonoBehaviourRepositoryLoader
By: Digitalroot

#### MonoBehaviourRepository.csproj

This is a simple project where each custom `MonoBehaviour` is defined as a class (.cs). 
These classes are defined in the `global` namepace, which means there is no `namespace` 
keyword used. I think this is how **Unity** does it.

###### Example
``` C#
using UnityEngine;

public class MyCustomMonoBehaviour : MonoBehaviour
{
  public void Update()
  {
    gameObject.transform.Rotate(0, 5f, 0);
  }
}

```
<br/><br/>

#### Wizard.csproj

**Note:** There is a ref to **MonoBehaviourRepository.dll** in the **Wizard.csproj** file. 
I did this out of convence for testing. It is not required. Wizard.csproj does not have 
a hard dependency on **MonoBehaviourRepository.dll**

``` xml
    <Content Include="..\MonoBehaviourRepository\bin\Debug\MonoBehaviourRepository.dll">
      <Link>MonoBehaviourRepository.dll</Link>
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
    </Content>
```
<br/><br/>

##### MonoBehaviourRepositoryLoader.cs

This class adds **Extension** methods to the `GameObject` class and handles loading of **MonoBehaviourRepository.dll** 

###### Code
``` C#
using System;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace Wizard
{
  public static class MonoBehaviourRepositoryLoader
  {
    private static Assembly _monoBehaviourRepositoryAssembly;

    public static Assembly MonoBehaviourRepositoryAssembly
    {
      get
      {
        if (_monoBehaviourRepositoryAssembly != null) return _monoBehaviourRepositoryAssembly;
        var path = Path.Combine(AssemblyDirectory.FullName, "MonoBehaviourRepository.dll");
        _monoBehaviourRepositoryAssembly = Assembly.LoadFile(path);
        return _monoBehaviourRepositoryAssembly;
      }
    }

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

    #region GameObject Extensions

    public static GameObject AddMonoBehaviour(this GameObject gameObject, string name)
    {
      Type type = Assembly.GetExecutingAssembly().GetType(name) ?? MonoBehaviourRepositoryAssembly.GetType(name);

      if (type == null)
      {
        throw new ArgumentException($"Unable to find MonoBehaviour: {name}", nameof(name));
      }

      gameObject.AddComponent(type);
      return gameObject;
    }

    public static GameObject AddMonoBehaviour<T>(this GameObject gameObject) where T : MonoBehaviour
    {
      gameObject.AddComponent<T>();
      return gameObject;
    }

    public static MonoBehaviour GetOrAddMonoBehaviour(this GameObject gameObject, string name)
    {
      return (gameObject.GetComponent(name) ?? gameObject.AddMonoBehaviour(name).GetComponent(name)) as MonoBehaviour;
    }

    /// <summary>
    /// Returns the component of Type type. If one doesn't already exist on the GameObject it will be added.
    /// Source: Jotunn JVL
    /// </summary>
    /// <remarks>Source: https://wiki.unity3d.com/index.php/GetOrAddComponent</remarks>
    /// <typeparam name="T">The type of Component to return.</typeparam>
    /// <param name="gameObject">The GameObject this Component is attached to.</param>
    /// <returns>Component</returns>
    public static T GetOrAddMonoBehaviour<T>(this GameObject gameObject) where T : MonoBehaviour
    {
      return gameObject.GetComponent<T>() ?? gameObject.AddComponent<T>();
    }

    #endregion
  }
}
```
<br/><br/>

#### Usage
To add a MonoBehaviour to a `GameObject` use one of the extension methods. 
<br><br>
**Order of precedence is:**
- Is the custom `MonoBehaviour` type already defined by Valheim or the plug-in?
   - Yes, use it
   - No, look in the `MonoBehaviourRepository`
   - otherwise an `ArgumentException` is thrown
<br><br>
###### Example
``` C#
        private void LoadAssets()
        {
            wizard = GetAssetBundleFromResources("wizard");
            Debug.Log("Loading Wizard");
            Wizard = wizard.LoadAsset<GameObject>("Wizard");
            Wizard.AddMonoBehaviour(CustomMonoBehavioursNames.MyCustomMonoBehaviour); // extension method
            Wizard.GetOrAddMonoBehaviour(CustomMonoBehavioursNames.UnRemoveableCustomMonoBehaviour); // extension method
            wizard?.Unload(false);
        }
```
<br/><br/>

#### Magic Strings
To avoid the usage of [Magic Strings](https://en.wikipedia.org/wiki/Magic_string), 
a `static` `class` with `public static strings` is used. This is not required, but 
is strongly encouraged.

###### CustomMonoBehavioursNames
``` C#
    public static class CustomMonoBehavioursNames
    {
      public static string MyCustomMonoBehaviour = nameof(MyCustomMonoBehaviour);
      public static string UnRemoveableCustomMonoBehaviour = nameof(UnRemoveableCustomMonoBehaviour);
    }
```
<br/><br/>

#### Proof of concept
This is a screen shot of the **Wizard** spawned in game with the two custom `MonoBehaviours` attached.
<br/><br>
<img src="https://raw.githubusercontent.com/Digitalroot-Valheim/Digitalroot.CustomMonoBehaviours/main/docs/example.png" alt="example" />
