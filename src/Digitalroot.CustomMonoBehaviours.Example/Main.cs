using BepInEx;
using Digitalroot.CustomMonoBehaviours.Extensions;
using JetBrains.Annotations;
using System;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace Digitalroot.CustomMonoBehaviours.Example
{
  [BepInPlugin(Guid, Name, Version)]
  public class Main : BaseUnityPlugin
  {
    public const string Version = "1.0.0";
    public const string Name = "Digitalroot CMB Example";
    private const string Guid = "digitalroot.cmb.example";
    public const string Namespace = nameof(Example);
    
    [UsedImplicitly]
    private void Awake()
    {
      try
      {
        RepositoryLoader.LoadAssembly("Digitalroot.CMB.Repository.dll");  // CMB can be loaded from more then one DLL. 
        RepositoryLoader.LoadAssembly(new FileInfo("Digitalroot.CMB.Repository2.dll")); // CMB can be loaded from more then one DLL. 
        LoadAssets();
      }
      catch (Exception e)
      {
        Jotunn.Logger.LogError(e);
      }
    }

    private void LoadAssets()
    {
      try
      {
        Debug.Log("Loading Wizard");
        var wizardAssetBundle = Jotunn.Utils.AssetUtils.LoadAssetBundleFromResources("wizard", Assembly.GetExecutingAssembly());
        var wizard = wizardAssetBundle.LoadAsset<GameObject>("Wizard");
        // wizard.AddMonoBehaviour(CustomMonoBehavioursNames.CMB_SpinClockwise); // Loaded from Digitalroot.CMB.Repository.dll
        wizard.AddMonoBehaviour(CustomMonoBehavioursNames.CMB_SpinCounterClockwise); // Loaded from Digitalroot.CMB.Repository2.dll
        Jotunn.Managers.PrefabManager.Instance.AddPrefab(wizard);
        wizardAssetBundle.Unload(false);
      }
      catch (Exception e)
      {
        Jotunn.Logger.LogError(e);
      }
    }
  }
}
