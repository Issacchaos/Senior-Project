﻿using UnityEngine;
using System.Collections;

public class woodsSpecialBulletScript : MonoBehaviour {
	
	private float speed = 15.0f;
	private GameObject woodsPlayer;
	private int numPiercing = 0;
	public float heldTime = 0.0f;
	private bool infinitePierce = false;
	// Use this for initialization
	void Start () 
	{
		/*GameObject playerManager = GameObject.FindGameObjectWithTag("PlayerManager");
		PlayerManager playerManagerScript = playerManager.GetComponent<PlayerManager> ();
		for (int i=0; i<playerManagerScript.numPlayers; i++)
		{
			if(playerManagerScript.players[i].GetComponent<PlayerBase>().classType == playerClass.WOODSMAN)
			{
				woodsPlayer = playerManagerScript.players[i];
			}
		}
		playerForward = woodsPlayer.transform.forward;
		transform.forward = playerForward;*/
		if (heldTime > 5.0f) 
		{
			infinitePierce = true;
		} 
		else 
		{

		}
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.position = transform.position + (transform.up * speed * Time.deltaTime);
	}
	
	void OnCollisionEnter(Collision c)
	{
		Destroy (gameObject);
	}
}
