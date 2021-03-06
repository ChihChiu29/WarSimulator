﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using math;
using resource;
using util;

[RequireComponent (typeof(Unit), typeof(CircleCollider2D))]
public class RangedAttack : MonoBehaviour
{
  Unit unit;
  CircleCollider2D sight;

  private Alarm alarm;

  void Start ()
  {
    unit = GetComponent<Unit> ();
    sight = GetComponent<CircleCollider2D> ();

    alarm = new Alarm (Time.time, unit.rangedAttackReloadTimeSec);
  }

  void Update ()
  {
    if (alarm.CheckTimeUp (Time.time)) {
      Fire (transform.TransformPoint (Vector2.up));
    }
  }

  //  void OnTriggerEnter2D (Collider2D coll)
  //  {
  //    MaybeFire (coll);
  //  }
  //
  //  void OnTriggerStay2D (Collider2D coll)
  //  {
  //    Debug.Log (Time.time);
  //    MaybeFire (coll);
  //  }
  //
  //  private void MaybeFire (Collider2D coll)
  //  {
  //    Unit collUnit = coll.gameObject.GetComponent<Unit> ();
  //    if (collUnit == null) {
  //      return;
  //    }
  //
  //    if (collUnit.faction == unit.faction) {
  //      return;
  //    }
  //
  //    float relativeAngle =
  //      Angle.GetLocalAngleTowards (transform, coll.gameObject.transform.position);
  //    if (Mathf.Abs (relativeAngle) > unit.rangedAttackAngleDeg) {
  //      return;
  //    }
  //
  //    if (alarm.CheckTimeUp (Time.time)) {
  //      Fire (Vec2.FromVector3 (coll.gameObject.transform.position));
  //    }
  //  }

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

    proj.GetComponent<Projectile> ().fromFaction = unit.faction;
    return proj;
  }
}
