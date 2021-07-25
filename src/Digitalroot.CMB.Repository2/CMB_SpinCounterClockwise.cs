using JetBrains.Annotations;
using UnityEngine;

/// <inheritdoc />
// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
public class CMB_SpinCounterClockwise : MonoBehaviour
{
  [UsedImplicitly]
  public void FixedUpdate()
  {
    gameObject.transform.Rotate(0, -5f, 0);
  }
}
