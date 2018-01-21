using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using math;

[RequireComponent (typeof(Unit))]
public class MouseController : MonoBehaviour
{
  Unit unit;
  // Use this for initialization
  void Start ()
  {
    unit = GetComponent<Unit> ();
  }

  // Update is called once per frame
  void Update ()
  {
    switch (unit.faction) {
    case 1:
      if (Input.GetKeyDown (KeyCode.Alpha1)) {
        GoToMousePostion ();
      }
      break;
    case 2:
      if (Input.GetKeyDown (KeyCode.Alpha2)) {
        GoToMousePostion ();
      }
      break;
    case 3:
      if (Input.GetKeyDown (KeyCode.Alpha3)) {
        GoToMousePostion ();
      }
      break;
    }
  }

  private void GoToMousePostion ()
  {
    unit.destination = Vec2.FromVector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition));
  }
}
