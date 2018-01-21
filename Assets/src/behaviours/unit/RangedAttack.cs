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

  void OnTriggerStay2D (Collider2D coll)
  {
    float tt = Time.time;
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
