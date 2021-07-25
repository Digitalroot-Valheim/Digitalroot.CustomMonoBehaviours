using JetBrains.Annotations;
using UnityEngine;

/// <inheritdoc />
// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
public class CMB_UnRemoveable : MonoBehaviour
{
  [UsedImplicitly]
  public void Start()
  {
    gameObject.GetComponent<Piece>().m_canBeRemoved = false;
  }
}