using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
  // === Tag ===
  // Which faction does the unit belongs to.
  public int faction = 1;
  // Which formation does the unit belongs to.
  public int formationGroup = 1;

  // === HP ===
  public int maxHp = 100;
  public int currentHp = 100;

  // === Attack ===
  public int attackPower = 1;

  // === Movement ===
  public Vector2 destination = Vector2.zero;
  // Where to apply the force during movement; relative to the center.
  public Vector2 applyForceAtRelativePoint = Vector2.zero;
  // Controls movement style.
  public float maxVelocity = 0;
  public float force = 0;
}
