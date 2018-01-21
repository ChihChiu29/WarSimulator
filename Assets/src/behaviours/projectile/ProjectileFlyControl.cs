using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Projectile), typeof(Rigidbody2D))]
public class ProjectileFlyControl : MonoBehaviour
{
  Projectile projectile;

  // Use this for initialization
  void Start ()
  {
    projectile = GetComponent<Projectile> ();
  }
	
  // Update is called once per frame
  void Update ()
  {
		
  }
}
