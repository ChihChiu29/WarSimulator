using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Unit))]
public class MeleeAttack : MonoBehaviour
{
  Unit unit;

  void Start ()
  {
    unit = GetComponent<Unit> ();
  }

  void OnCollisionEnter2D (Collision2D coll)
  {
    MaybeApplyDamage (coll);
  }

  void OnCollisionStay2D (Collision2D coll)
  {
    MaybeApplyDamage (coll);
  }

  private void MaybeApplyDamage (Collision2D coll)
  {
    Unit collUnit = coll.gameObject.GetComponent<Unit> ();
    if (collUnit == null) {
      return;
    }

    if (collUnit.faction == unit.faction) {
      return;
    }

    Vector2 relativePosition = transform.InverseTransformPoint (coll.gameObject.transform.position);
    if (relativePosition.y <= 0) {
      // Can only attack forward.
      return;
    }
    collUnit.currentHp -= unit.meleeAttackPower * relativePosition.y / relativePosition.magnitude;
  }
}
