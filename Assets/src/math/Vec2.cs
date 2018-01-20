using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace math
{
  public class Vec2
  {
    // Transforms a relative point to world coordinates.
    public static Vector2 transformPoint2D (
      GameObject gameObject, 
      Vector2 relativePoint)
    {
      Vector3 newCoords = gameObject.transform.TransformPoint (
                            new Vector3 (relativePoint.x, relativePoint.y, 0));
      return new Vector2 (newCoords.x, newCoords.y);
    }
  }
}