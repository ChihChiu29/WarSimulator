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
  public float maxHp = 100;
  public float currentHp = 100;

  // === Attack ===
  // # Melee
  // Melee attack can only be applied to +/- 90 deg relative to the front direction, and the
  // damage scales down from front attack to side attack.
  public float meleeAttackPower = 0;
  // # Ranged
  // Can only attack within +/- this angle relative to the front direction.
  public float rangedAttackAngleDeg = 45;
  public float rangedAttackReloadTimeSec = 1;
  // Where to create projectile for ranged attack.
  public Vector2 projectileCreationRelativePoint = Vector2.zero;
  // What projectile to create when firing.
  public string projectilePrefabName = "";
  public float projectileVeclority = 0;

  // === Movement ===
  public Vector2 destination = Vector2.zero;
  // Where to apply the force during movement; relative to the center.
  public Vector2 applyForceAtRelativePoint = Vector2.zero;
  // Controls movement style.
  public float maxVelocity = 0;
  public float movementForce = 0;
}
