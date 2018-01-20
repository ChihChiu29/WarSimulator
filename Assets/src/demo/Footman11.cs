using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using game.formation;
using math;

public class Footman11 : MonoBehaviour
{

  // Use this for initialization
  void Start ()
  {
    GameObject[] units;
    units = FormationFactory.CreateRectFormation (
      "Footman",
      center: new Vector2 (-20, 0),
      facingAngle: -90,
      width: 45,
      depth: 15,
      numColumns: 30,
      numRows: 10);

    foreach (GameObject unitObj in units) {
      Unit unit = unitObj.GetComponent<Unit> ();
      unit.faction = 1;
      unit.formationGroup = 1;
      unit.destination = Vec2.FromVector3 (unitObj.transform.position);
    }


    units = FormationFactory.CreateRectFormation (
      "Footman",
      center: new Vector2 (20, 0),
      facingAngle: 90,
      width: 18,
      depth: 18,
      numColumns: 12,
      numRows: 12);

    Vector2 marchLeft = new Vector2 (-500, 0);
    foreach (GameObject unitObj in units) {
      Unit unit = unitObj.GetComponent<Unit> ();
      unit.faction = 2;
      unit.formationGroup = 1;
      unit.destination = Vec2.FromVector3 (unitObj.transform.position) + marchLeft;
    }
  }
}
