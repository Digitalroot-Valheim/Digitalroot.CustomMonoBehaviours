using JetBrains.Annotations;
using System.Diagnostics.CodeAnalysis;

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
