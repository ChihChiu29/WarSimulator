using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
  // === TAG ===
  // Unit from which faction fired the projectile.
  public int fromFaction = 1;

  // === Damage ===
  public float directDamage = 0;
  // If set, can also create explosion at the point of contact.
  public string createExplosionPrefabName = "";
}
