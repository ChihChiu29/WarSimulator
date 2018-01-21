using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using game.formation;
using math;

public class FootmanVsKnight2 : MonoBehaviour
{

  // Use this for initialization
  void Start ()
  {
    GameObject[] units;
    float facingAngle;

    // Left army.
    facingAngle = -90;
    units = FormationFactory.CreateRectFormation (
      "Footman",
      center: new Vector2 (-40, 0),
      facingAngle: facingAngle,
      width: 60,
      depth: 25,
      numColumns: 50,
      numRows: 20);

    foreach (GameObject unitObj in units) {
      Unit unit = unitObj.GetComponent<Unit> ();
      unit.faction = 1;
      unit.formationGroup = 1;
      unit.destination = new Vector2 (20, 0);
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
      unit.destination = new Vector2 (-100, 0);
    }

    // Right army.
    facingAngle = 90;
    units = FormationFactory.CreateRectFormation (
      "Knight",
      center: new Vector2 (200, 0),
      facingAngle: facingAngle,
      width: 14,
      depth: 30,
      numColumns: 10,
      numRows: 8);

    foreach (GameObject unitObj in units) {
      Unit unit = unitObj.GetComponent<Unit> ();
      unit.faction = 2;
      unit.formationGroup = 2;
      unit.destination = new Vector2 (-100, 0);
    }
  }
}
