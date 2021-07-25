using JetBrains.Annotations;
using UnityEngine;

/// <inheritdoc />
// ReSharper disable once CheckNamespace
// ReSharper disable once InconsistentNaming
public class CMB_SpinClockwise : MonoBehaviour
{
  [UsedImplicitly]
  public void FixedUpdate()
  {
    gameObject.transform.Rotate(0, 5f, 0);
  }
}