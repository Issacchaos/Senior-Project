﻿using UnityEngine;
using System.Collections;
using Exploder;

public class BasicArrow : ProjectileTrapObj
{
	public bool basic = true;
	private Woodsman woodsman;
	private GameObject hawk;
	private HawkAI2 hawkScript;
	public  int numPierces = 0;

	public void PostEnable(bool basicA)
	{
		basic = basicA;
	}

	private void Start()
	{
		woodsman = GameObject.Find("Woodsman(Clone)").GetComponent<Woodsman>();
		hawk = GameObject.FindGameObjectWithTag("Hawk");
		hawkScript = hawk.GetComponent<HawkAI2>();
	}
	
	protected override void HitObject (Transform t)
	{
		if(t.collider.GetComponent<Explodable>() != null)
		{
			t.collider.SendMessage("Boom");
		}
		if(t.gameObject.CompareTag("Enemy"))
		{
			EnemyBase scr = t.gameObject.GetComponent<EnemyBase>();
			float bonus = 1.0f;
			if(!basic)
			{
				bonus = 1.2f;
			}
			scr.takeDamage(damage * bonus);
			scr.damageTaken += damage * bonus;
			if(hawkScript.enemiesToAttack.Contains(t.gameObject) == false)
			{
				hawkScript.enemiesToAttack.Add (t.gameObject);
			}
			woodsman.hitCount += 1;
		}
		else if(t.gameObject.CompareTag("wall"))
		{
			gameObject.SetActive(false);
		}
	}
}