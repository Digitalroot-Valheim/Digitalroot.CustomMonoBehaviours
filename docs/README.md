[![Build](https://github.com/Digitalroot-Valheim/Digitalroot.CustomMonoBehaviours/actions/workflows/builder.yml/badge.svg)](https://github.com/Digitalroot-Valheim/Digitalroot.CustomMonoBehaviours/actions/workflows/builder.yml)
[![NuGet Package](https://github.com/Digitalroot-Valheim/Digitalroot.CustomMonoBehaviours/actions/workflows/publish.yml/badge.svg)](https://github.com/Digitalroot-Valheim/Digitalroot.CustomMonoBehaviours/actions/workflows/publish.yml)
[![Release Drafter](https://github.com/Digitalroot-Valheim/Digitalroot.CustomMonoBehaviours/actions/workflows/drafter.yml/badge.svg)](https://github.com/Digitalroot-Valheim/Digitalroot.CustomMonoBehaviours/actions/workflows/drafter.yml)

# Digitalroot's Custom MonoBehaviours (CMB)

This repository is trying to answer the question. How do I get custom `MonoBehaviour`s out of Unity and into Valheim? 

## License
:heavy_dollar_sign: Closed-source license is available for commercial or personal use.

### :warning: WARNING :warning:
- **Upload permission:** You are not allowed to upload any files in this repository to other sites under any circumstances.  
- **Asset use permission:** You are not allowed to use any of the assets; Unity assets, image files, and icon file, in this repository under any circumstances.    

### Open Source License
- Is your code private, closed-source, or proprietary?
- Do you charge money to use your code?
- Is your code **not** compatable with **GNU Affero General Public License v3.0**?

:exclamation: If you answered **YES** to any of the above, you must acquire a Closed-source license. :exclamation:

:page_with_curl: If you answered **NO** to all the above questions. You may:
- Direct your users to download the DLL from the GitHub [Releases](https://github.com/Digitalroot-Valheim/Digitalroot.CustomMonoBehaviours/releases) page.
- Direct your users to download the DLL from the [nexusmods.com](https://www.nexusmods.com/valheim/mods/1401) page.

#### :man_judge: Exemptions :woman_judge:
- 1st Exemption: You may [IL Weave](https://michielsioen.be/2017-10-21-il-weaving/) the DLL into your own DLL, if, and only if, you meet the requirements for the [Open Source License](#open-source-license) and you include, in your **ReadMe** file and **Main page** for downloading your code, one of the following [statements](#statements) in clear readable font at 12pt or higher. Take a look at [ILMerge.Fody](https://github.com/tom-englert/ILMerge.Fody) for your IL Weaving needs.

- 2nd Exemption: You may include the DLL as part of a collection of DLLs aka **Mod Packs**, if, and only if, you meet the requirements for the [Open Source License](#open-source-license) and you include, in your **ReadMe** file and **Main page** for downloading your collection, one of the following [statements](#statements) in clear readable font at 12pt or higher.

###### Statements 

HTML  
```html
Uses <a href="https://tinyurl.com/drcmbs">Digitalroot's Custom MonoBehaviours</a> 
```
Markdown  
```markdown
Uses [Digitalroot's Custom MonoBehaviours](https://tinyurl.com/drcmbs)
```
Text  
```
Uses Digitalroot's Custom MonoBehaviours - https://tinyurl.com/drcmbs
```

## TL:DR Documentation

Tell the `RepositoryLoader` to load your DLL. I put this in `Awake`

```c#
RepositoryLoader.LoadAssembly("Digitalroot.CMB.Repository.dll");
```

Later when loading your asset, attach your CMB to the `GameObject`

```c#
Debug.Log("Loading Wizard");
var wizardAssetBundle = Jotunn.Utils.AssetUtils.LoadAssetBundleFromResources("wizard", Assembly.GetExecutingAssembly());
var wizard = wizardAssetBundle.LoadAsset<GameObject>("Wizard");
wizard.AddMonoBehaviour("CMB_SpinClockwise"); // Loaded from Digitalroot.CMB.Repository.dll
Jotunn.Managers.PrefabManager.Instance.AddPrefab(wizard);
wizardAssetBundle.Unload(false);
```

[Full Example](https://github.com/Digitalroot-Valheim/Digitalroot.CustomMonoBehaviours/blob/main/src/Digitalroot.CustomMonoBehaviours.Example/Main.cs)

## Documentation
Check out the [Wiki](https://github.com/Digitalroot-Valheim/Digitalroot.CustomMonoBehaviours/wiki)

## Installation
There are a few choices for installation:
1. Install the NuGet package via dotnet cli. `dotnet add PROJECT package Digitalroot.CustomMonoBehaviours`
1. Install the NuGet package via Package Manager. `PM>` `Install-Package Digitalroot.CustomMonoBehaviours`
1.  For projects that support PackageReference, copy this XML node into the project file to reference the package. <br />`<PackageReference Include="Digitalroot.CustomMonoBehaviours" Version="1.0.*" />`
1. Download the [NuGet Package](https://github.com/Digitalroot-Valheim/Digitalroot.CustomMonoBehaviours/packages/912070) from GitHub.
1. Download the DLL from the GitHub [Releases](https://github.com/Digitalroot-Valheim/Digitalroot.CustomMonoBehaviours/releases) page.

## Thanks to 
- [Digitalroot](https://github.com/Digitalroot)
- [sbtoonz](https://github.com/sbtoonz)
- The [๖̶̶̶ζ͜͡Odin Plus Team)](https://discord.gg/BHbTumqG7U) Discord community. 
- The [Valheim Discord](https://discord.gg/GUEBuCuAMz) community.

![OdinPlus](https://raw.githubusercontent.com/Digitalroot-Valheim/OdinPlusRemakeJVL/Update/img/OdinTeamHighRezNuGet.png)
