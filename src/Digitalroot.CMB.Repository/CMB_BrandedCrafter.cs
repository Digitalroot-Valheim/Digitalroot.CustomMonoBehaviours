using JetBrains.Annotations;
using UnityEngine;

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
