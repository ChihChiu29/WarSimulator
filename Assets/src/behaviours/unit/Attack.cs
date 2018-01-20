using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Unit))]
public class Attack : MonoBehaviour
{
  Unit unit;
  // Use this for initialization
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

    collUnit.currentHp -= unit.attackPower;
  }
}
