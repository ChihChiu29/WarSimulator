using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using game.formation;
using math;

public class FvsSvsK : MonoBehaviour
{

  // Use this for initialization
  void Start ()
  {
    GameObject[] units;
    Vector2 marchUp = new Vector2 (0, 500);
    float facingAngle;

    // Left army.
    facingAngle = -90;
    units = FormationFactory.CreateRectFormation (
      "Footman",
      center: new Vector2 (-40, 0),
      facingAngle: facingAngle,
      width: 45,
      depth: 15,
      numColumns: 30,
      numRows: 10);

    foreach (GameObject unitObj in units) {
      Unit unit = unitObj.GetComponent<Unit> ();
      unit.faction = 1;
      unit.formationGroup = 1;
      unit.destination = 
        Vec2.FromVector3 (unitObj.transform.position) + Vec2.RotateCounterClockwise (marchUp, facingAngle);
    }

    // Upper-right army.
    facingAngle = 150;
    units = FormationFactory.CreateRectFormation (
      "Spearman",
      center: new Vector2 (20, 35),
      facingAngle: facingAngle,
      width: 45,
      depth: 15,
      numColumns: 30,
      numRows: 10);

    foreach (GameObject unitObj in units) {
      Unit unit = unitObj.GetComponent<Unit> ();
      unit.faction = 2;
      unit.formationGroup = 1;
      unit.destination = 
        Vec2.FromVector3 (unitObj.transform.position) + Vec2.RotateCounterClockwise (marchUp, facingAngle);
    }

    // Lower-right army.
    facingAngle = 30;
    units = FormationFactory.CreateRectFormation (
      "Knight",
      center: new Vector2 (40, -70),
      facingAngle: facingAngle,
      width: 20,
      depth: 40,
      numColumns: 12,
      numRows: 10);

    foreach (GameObject unitObj in units) {
      Unit unit = unitObj.GetComponent<Unit> ();
      unit.faction = 3;
      unit.formationGroup = 1;
      unit.destination = 
        Vec2.FromVector3 (unitObj.transform.position) + Vec2.RotateCounterClockwise (marchUp, facingAngle);
    }
  }
}
