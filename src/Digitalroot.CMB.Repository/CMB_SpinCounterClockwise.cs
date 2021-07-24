using JetBrains.Annotations;
using UnityEngine;

/// <inheritdoc />
// ReSharper disable once CheckNamespace
public class SpinCounterClockwise : MonoBehaviour
{
  [UsedImplicitly]
  public void FixedUpdate()
  {
    gameObject.transform.Rotate(0, -5f, 0);
  }
}
