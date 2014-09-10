﻿using UnityEngine;
using System.Collections;

public class Doorway : MonoBehaviour 
{
	private MapManager mapMan;

	public Direction doorwayDirection;
	public bool transitioning = false;
	private float transitionTimer = 1.5f;

	void Start()
	{
		mapMan = GameObject.Find("MapManager").GetComponent<MapManager>();
	}

	void OnTriggerExit(Collider c)
	{
		if (c.gameObject.tag == "Player")
		{
			Vector3 playerToDoorway = (transform.position - c.transform.position).normalized;

			// If player is leaving room
			if (Vector3.Dot(playerToDoorway, c.transform.forward) > 0)
			{
				mapMan.playerLeaveRoom(transform.parent.name);
			}
		}
	}

	void Update()
	{
		/*
		if (transitioning && transitionTimer > 0.0f)
		{
			transitionTimer -= Time.deltaTime;
			if (transitionTimer <= 0.0f)
			{
				mapMan.moveToNewRoom(doorwayDirection);
			}
		}
		*/
	}
}
