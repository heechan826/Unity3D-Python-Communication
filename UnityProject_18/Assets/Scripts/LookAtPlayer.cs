using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class LookAtPlayer : MonoBehaviour {

	// Use this for initialization
	[SerializeField] private Transform target;

	[SerializeField] private int x;
	[SerializeField] private int y;
	[SerializeField] private int z;

	// Update is called once per frame
	void Update () 
	{
		transform.LookAt(target);
		transform.Rotate(x, y, z);
	}
}
