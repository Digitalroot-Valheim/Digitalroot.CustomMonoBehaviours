using JetBrains.Annotations;
using System;
using UnityEngine;

namespace Digitalroot.CustomMonoBehaviours.Extensions
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
  public static class GameObjectExtensions
  {
    /// <summary>
    /// Add a Custom Mono Behaviour to a GameObject.
    /// Use RepositoryLoader.LoadAssembly() to load your Custom Mono Behaviour Repositories first.
    /// </summary>
    /// <param name="gameObject">GameObject to add the Custom Mono Behaviour to.</param>
    /// <param name="name">Name of the Custom Mono Behaviour type to add.</param>
    /// <returns>The GameObject with the Custom Mono Behaviour attached.</returns>
    [UsedImplicitly]
    public static GameObject AddMonoBehaviour([NotNull] this GameObject gameObject, [NotNull] string name)
    {
      Type type = RepositoryLoader.GetCustomMonoBehaviour(name);

      if (type == null)
      {
        throw new ArgumentException($"Unable to find MonoBehaviour: {name}", nameof(name));
      }

      if (!type.IsSubclassOf(typeof(MonoBehaviour)))
      {
        throw new TypeLoadException($"Type: {name} is not a MonoBehaviour");
      }

      gameObject.AddComponent(type);
      return gameObject;
    }

    /// <summary>
    /// Add a Custom Mono Behaviour to a GameObject.
    /// Use RepositoryLoader.LoadAssembly() to load your Custom Mono Behaviour Repositories first.
    /// </summary>
    /// <typeparam name="T">Type of the Custom Mono Behaviour to add.</typeparam>
    /// <param name="gameObject">GameObject to add the Custom Mono Behaviour to.</param>
    /// <returns>The GameObject with the Custom Mono Behaviour attached.</returns>
    [UsedImplicitly]
    public static GameObject AddMonoBehaviour<T>([NotNull] this GameObject gameObject) where T : MonoBehaviour
    {
      gameObject.AddComponent<T>();
      return gameObject;
    }

    /// <summary>
    /// Get a component from a GameObject. If one doesn't already exist on the GameObject it will be added.
    /// </summary>
    /// <remarks>
    /// Inspired by Jotunn JVL
    /// Source: https://wiki.unity3d.com/index.php/GetOrAddComponent
    /// </remarks>
    /// <param name="gameObject">The GameObject the Component is attached to.</param>
    /// <param name="name">The name of the Component to return</param>
    /// <returns>Returns the component of Type T</returns>
    [UsedImplicitly]
    public static MonoBehaviour GetOrAddMonoBehaviour([NotNull] this GameObject gameObject, [NotNull] string name)
    {
      return (gameObject.GetComponent(name) ?? gameObject.AddMonoBehaviour(name).GetComponent(name)) as MonoBehaviour;
    }

    /// <summary>
    /// Returns the component of Type type. If one doesn't already exist on the GameObject it will be added.
    /// </summary>
    /// <remarks>
    /// Inspired by Jotunn JVL
    /// Source: https://wiki.unity3d.com/index.php/GetOrAddComponent
    /// </remarks>
    /// <typeparam name="T">The type of Component to return.</typeparam>
    /// <param name="gameObject">The GameObject the Component is attached to.</param>
    /// <returns>Returns the component of Type T</returns>
    [UsedImplicitly]
    public static T GetOrAddMonoBehaviour<T>([NotNull] this GameObject gameObject) where T : MonoBehaviour
    {
      return gameObject.GetComponent<T>() ?? gameObject.AddComponent<T>();
    }
  }
}
