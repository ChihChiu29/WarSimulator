using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Unit), typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
  // Used to check if the unit is at destination.
  private const float DESTINATION_CHECK_ERROR = 0.1f;

  private Unit unit;
  private Rigidbody2D rigidbody2d;

  // Use this for initialization
  void Start ()
  {
    unit = GetComponent<Unit> ();
    rigidbody2d = GetComponent<Rigidbody2D> ();
  }
	
  // Update is called once per frame
  void Update ()
  {
    if (doesArriveDestination () || doesHaveMaxVelocity ()) {
      return;
    }
    rigidbody2d.AddForceAtPosition (
      calculateForce (), 
      math.Vec2.TransformPoint2D (gameObject, unit.applyForceAtRelativePoint));
  }

  public bool doesArriveDestination ()
  {
    return getVectorTowardsDestination ().magnitude < DESTINATION_CHECK_ERROR;
  }

  public bool doesHaveMaxVelocity ()
  {
    return rigidbody2d.velocity.magnitude > unit.maxVelocity;
  }

  // Assumes you have checked for if applying a force is necessary.
  private Vector2 calculateForce ()
  {
    Vector2 relativeDestination = getVectorTowardsDestination ();
    return relativeDestination / relativeDestination.magnitude * unit.force;
  }

  private Vector2 getPosition ()
  {
    return new Vector2 (
      gameObject.transform.position.x, gameObject.transform.position.y);
  }

  private Vector2 getVectorTowardsDestination ()
  {
    return unit.destination - getPosition ();
  }
}
