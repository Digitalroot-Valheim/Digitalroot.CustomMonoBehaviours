using BepInEx;
using Digitalroot.CustomMonoBehaviours.Extensions;
using JetBrains.Annotations;
using System;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Reflection;
using UnityEngine;

namespace Digitalroot.CustomMonoBehaviours.Example
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
        RepositoryLoader.LoadAssembly("Digitalroot.CMB.Repository.dll"); // CMB can be loaded from more then one DLL. 
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
        wizard.AddMonoBehaviour(CustomMonoBehavioursNames.CMB_SpinClockwise); // Loaded from Digitalroot.CMB.Repository.dll
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

  [UsedImplicitly]
  [SuppressMessage("ReSharper", "InconsistentNaming")]
  public static class CustomMonoBehavioursNames
  {
    public static string CMB_BrandedCrafter = nameof(CMB_BrandedCrafter);
    public static string CMB_SpinClockwise = nameof(CMB_SpinClockwise);
    public static string CMB_SpinCounterClockwise = nameof(CMB_SpinCounterClockwise);
    public static string CMB_UnRemoveable = nameof(CMB_UnRemoveable);
  }
}
