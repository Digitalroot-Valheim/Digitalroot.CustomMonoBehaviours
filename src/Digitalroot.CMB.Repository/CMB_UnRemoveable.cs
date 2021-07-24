using JetBrains.Annotations;
using UnityEngine;

/// <inheritdoc />
// ReSharper disable once CheckNamespace
public class UnRemoveableCustomMonoBehaviour : MonoBehaviour
{
  [UsedImplicitly]
  public void Start()
  {
    gameObject.GetComponent<Piece>().m_canBeRemoved = false;
  }
}