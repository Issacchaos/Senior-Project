﻿using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	public Transform target;
	public int moveSpeed;
	public int rotSpeed;

	private Transform myTransform;

	void Awake()
	{
		myTransform = transform;
	}
	// Use this for initialization
	void Start () {
		GameObject go = GameObject.FindGameObjectWithTag ("Player");
		target = go.transform;
		moveSpeed = 3;
		rotSpeed = 3;
	}
	
	// Update is called once per frame
	void Update () {
		Debug.DrawLine (target.position, myTransform.position, Color.yellow);
		// look at target
		myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (target.position - myTransform.position), rotSpeed * Time.deltaTime);
		// move towards target
		myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;

	}
}
