using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

  // Which faction does the unit belongs to.
  public int faction = 1;

  // Which formation does the unit belongs to.
  public int formation_group = 1;

  // The HP of the unit.
  public int maxHp = 100;
  public int currentHp = 100;
}
