using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Projectile))]
public class OnCollision : MonoBehaviour
{

  Projectile proj;

  void Start ()
  {
    proj = GetComponent<Projectile> ();
  }

  void OnCollisionEnter2D (Collision2D coll)
  {
    if (MaybeApplyDamage (coll)) {
      Object.Destroy (gameObject);
    }
  }

  private bool MaybeApplyDamage (Collision2D coll)
  {
    Unit collUnit = coll.gameObject.GetComponent<Unit> ();
    if (collUnit == null) {
      return false;
    }

    if (collUnit.faction == proj.fromFaction) {
      return false;
    }
      
    collUnit.currentHp -= proj.directDamage;
    return true;
  }
}
