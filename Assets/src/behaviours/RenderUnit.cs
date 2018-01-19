using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Unit))]
[RequireComponent (typeof(TextMesh))]
public class RenderUnit : MonoBehaviour
{

  Unit unit;
  TextMesh textMesh;

  private int previousHp;
  private Color factionColor;

  private Color deadColor = Color.grey;

  // Use this for initialization
  void Start ()
  {
    unit = GetComponent<Unit> ();
    textMesh = GetComponent<TextMesh> ();

    previousHp = unit.currentHp;
    factionColor = GetColorForFactor (unit.faction);
  }
	
  // Update is called once per frame
  void Update ()
  {
//    if (previousHp == unit.currentHp) {
//      return;
//    }

    SetColorAccordingToHealth ();
    MaybeKillMe ();

  }

  private Color GetColorForFactor (int factor)
  {
    switch (unit.faction) {
    case 1:
      return Color.red;
    case 2:
      return Color.blue;
    default:
      return Color.yellow; 
    }
  }

  private void SetColorAccordingToHealth ()
  {
    Color cc = deadColor + (float)unit.currentHp / unit.maxHp * (factionColor - deadColor);
    textMesh.color = deadColor + (float)unit.currentHp / unit.maxHp * (factionColor - deadColor);
  }

  private void MaybeKillMe ()
  {
    if (unit.currentHp <= 0) {
      Object.Destroy (gameObject);
    }
  }
}
