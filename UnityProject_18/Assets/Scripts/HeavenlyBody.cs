﻿using UnityEngine;
using System.Collections;

public class HeavenlyBody : MonoBehaviour {
	public float speed = 30.0f;
	// Use this for initialization
	void Start () {
		//GameObject go = GameObject.Find("WhiteSample");
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.up, speed * Time.deltaTime);
	}
}
