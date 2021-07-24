using JetBrains.Annotations;
using UnityEngine;

/// <inheritdoc />
// ReSharper disable once CheckNamespace
public class BrandedCrafter : MonoBehaviour
{
  [UsedImplicitly]
  public void Awake()
  {
    var itemDrop = gameObject.GetComponent<ItemDrop>();
    itemDrop.m_itemData.m_crafterName = "Digitalroot";
    itemDrop.m_itemData.m_crafterID = 333L;
  }
}
