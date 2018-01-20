using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using math;

[RequireComponent (typeof(Unit))]
public class MouseController : MonoBehaviour
{
  public int mouseButton = 0;

  Unit unit;
  // Use this for initialization
  void Start ()
  {
    unit = GetComponent<Unit> ();
  }

  // Update is called once per frame
  void Update ()
  {
    if (Input.GetMouseButtonDown (mouseButton)) {
      unit.destination = Vec2.FromVector3 (Camera.main.ScreenToWorldPoint (Input.mousePosition));
    }
  }
}
