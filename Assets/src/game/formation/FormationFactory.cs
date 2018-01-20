using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace game
{
  namespace formation
  {
    public class FormationFactory
    {
      public static GameObject[] CreateRectFormation (
        string prefabName,
        Vector2 center = default(Vector2),
        // Counter-clockwise
        float facingAngle = 0f,
        // "x" direction
        float width = 10f,  
        // "y" direction
        float depth = 10f, 
        // "x" direction
        int numColumns = 3, 
        // "y" direction
        int numRows = 3)
      {
        int numUnits = numColumns * numRows;
        float columnSpacing;
        float rowSpacing;

        if (numColumns > 1) {
          columnSpacing = width / (numColumns - 1);
        } else {
          columnSpacing = 0f;
        }
        if (numRows > 1) {
          rowSpacing = depth / (numRows - 1);
        } else {
          rowSpacing = 0f;
        }

        Vector3[] positions = new Vector3[numUnits];

        int unitId = 0;
        // Create position vectors relative to (0,0) without rotation.
        for (int rowId = 0; rowId < numRows; ++rowId) {
          for (int colId = 0; colId < numColumns; ++colId) {
            positions [unitId].x = -width / 2 + colId * columnSpacing;
            positions [unitId].y = -depth / 2 + rowId * rowSpacing;
            positions [unitId].z = 0f;
            ++unitId;
          }
        }

        // Rotate then re-center.
        Vector3 center3d = new Vector3 (center.x, center.y, 0);
        Quaternion rotation = Quaternion.Euler (0, 0, facingAngle);
        for (unitId = 0; unitId < numUnits; ++unitId) {
          positions [unitId] = rotation * positions [unitId] + center3d;
        }

        // Create units.
        GameObject[] units = new GameObject[numUnits];
        for (unitId = 0; unitId < numUnits; ++unitId) {
          units [unitId] = resource.ObjectProvider.CreateGameObject (
            prefabName, 
            math.Vec2.FromVector3 (positions [unitId]),
            rotation: facingAngle);
        }

        return units;
      }
    }
  }
}