﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace math
{
  public class Angle
  {
    private static Vector2 xAxis = new Vector2 (1, 0);

    // Returns the angle of the vector targetLocation - baseLocation.
    // Returns: 0 means to the right.
    public static float GetAngleTowards (Vector2 baseLocation, Vector2 targetLocation)
    {
      Vector2 baseToTarget = targetLocation - baseLocation;
      if (baseToTarget.y > 0) {
        return Vector2.Angle (xAxis, baseToTarget);
      } else {
        return -Vector2.Angle (xAxis, baseToTarget);
      }
    }

    public static float GetLocalAngleTowards (Transform transform, Vector2 targetLocation)
    {
      Vector2 localDirectionToTarget = transform.InverseTransformPoint (targetLocation);
      return GetAngleBetween (Vector2.up, localDirectionToTarget); 
    }

    // Similar to GetAngleTowards, but 0 means up.
    public static float GetRotationAngleForCreatingObject (
      Vector2 baseLocation, 
      Vector2 targetLocation)
    {
      return GetAngleTowards (baseLocation, targetLocation) - 90;
    }

    // Same as Vector2.Angle, but with sign (counter-clockwisely).
    public static float GetAngleBetween (Vector2 start, Vector2 end)
    {
      if (end.y * start.x - end.x * start.y > 0) {
        return Vector2.Angle (start, end);
      } else {
        return -Vector2.Angle (start, end);
      }
    }
  }
}
