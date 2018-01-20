using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace math
{
  public class Vec2
  {
    public static Vector2 FromVector3 (Vector3 vector3)
    {
      return new Vector2 (vector3.x, vector3.y);
    }

    public static Vector3 ToVector3 (Vector2 vector2)
    {
      return new Vector3 (vector2.x, vector2.y, 0);
    }

    // Transforms a relative point to world coordinates.
    public static Vector2 TransformPoint2D (
      GameObject gameObject, 
      Vector2 relativePoint)
    {
      Vector3 newCoords = gameObject.transform.TransformPoint (
                            new Vector3 (relativePoint.x, relativePoint.y, 0));
      return new Vector2 (newCoords.x, newCoords.y);
    }

    public static Vector2 RotateCounterClockwise (Vector2 vec, float angle)
    {
      return FromVector3 (Quaternion.Euler (0, 0, angle) * ToVector3 (vec));
    }
  }
}