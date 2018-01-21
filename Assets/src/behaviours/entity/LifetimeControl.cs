using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using util;

public class LifetimeControl : MonoBehaviour
{
  public float lifetime = 0;

  private Alarm alarm;

  // Use this for initialization
  void Start ()
  {
    alarm = new Alarm (Time.time, lifetime);
  }
	
  // Update is called once per frame
  void Update ()
  {
    if (alarm.CheckTimeUp (Time.time)) {
      Object.Destroy (gameObject);
    }
  }
}
