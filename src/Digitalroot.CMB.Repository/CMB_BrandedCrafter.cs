﻿using JetBrains.Annotations;
using UnityEngine;

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

/// <inheritdoc />
// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
public class CMB_BrandedCrafter : MonoBehaviour
{
  [UsedImplicitly]
  public void Awake()
  {
    var itemDrop = gameObject.GetComponent<ItemDrop>();
    itemDrop.m_itemData.m_crafterName = "Digitalroot";
    itemDrop.m_itemData.m_crafterID = 333L;
  }
}
