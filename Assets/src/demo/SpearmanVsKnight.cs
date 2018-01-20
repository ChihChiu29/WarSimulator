using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using game.formation;
using math;

public class SpearmanVsKnight : MonoBehaviour
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
      "Spearman",
      center: new Vector2 (-40, 0),
      facingAngle: facingAngle,
      width: 60,
      depth: 45,
      numColumns: 50,
      numRows: 20);

    foreach (GameObject unitObj in units) {
      Unit unit = unitObj.GetComponent<Unit> ();
      unit.faction = 1;
      unit.formationGroup = 1;
      unit.destination = 
        Vec2.FromVector3 (unitObj.transform.position) + Vec2.RotateCounterClockwise (marchUp, facingAngle);
    }

    // Right army.
    facingAngle = 90;
    units = FormationFactory.CreateRectFormation (
      "Knight",
      center: new Vector2 (40, 0),
      facingAngle: facingAngle,
      width: 14,
      depth: 30,
      numColumns: 10,
      numRows: 8);

    foreach (GameObject unitObj in units) {
      Unit unit = unitObj.GetComponent<Unit> ();
      unit.faction = 2;
      unit.formationGroup = 1;
      unit.destination = 
        Vec2.FromVector3 (unitObj.transform.position) + Vec2.RotateCounterClockwise (marchUp, facingAngle);
    }
  }
}
