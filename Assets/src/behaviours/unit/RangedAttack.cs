using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using math;
using resource;
using util;

[RequireComponent (typeof(Unit), typeof(Collider2D))]
public class RangedAttack : MonoBehaviour
{
  Unit unit;

  private Alarm alarm;

  void Start ()
  {
    unit = GetComponent<Unit> ();
    alarm = new Alarm (Time.time, unit.rangedAttackReloadTimeSec);
  }

  void OnTriggerEnter2D (Collider2D coll)
  {
    MaybeFire (coll);
  }

  void OnTriggerStay2D (Collider2D coll)
  {
    Debug.Log (Time.time);
    MaybeFire (coll);
  }

  private void MaybeFire (Collider2D coll)
  {
    Unit collUnit = coll.gameObject.GetComponent<Unit> ();
    if (collUnit == null) {
      return;
    }

    if (collUnit.faction == unit.faction) {
      return;
    }
    if (alarm.CheckTimeUp (Time.time)) {
      Fire (Vec2.FromVector3 (coll.gameObject.transform.position));
    }
  }

  private GameObject Fire (Vector2 targetLocation)
  {
    Vector2 myPosition = Vec2.FromVector3 (gameObject.transform.position);
    float aa = Angle.GetRotationAngleForCreatingObject (myPosition, targetLocation);
    GameObject proj = ObjectProvider.CreateGameObject (
                        unit.projectilePrefabName, 
                        Vec2.TransformPoint2D (gameObject, unit.projectileCreationRelativePoint),
                        aa);
    Vector2 direction = targetLocation - myPosition;
    proj.transform.GetComponent<Rigidbody2D> ().velocity =
      direction / direction.magnitude * unit.projectileVeclority;
    return proj;
  }
}
