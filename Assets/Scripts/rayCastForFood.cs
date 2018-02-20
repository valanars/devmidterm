﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class rayCastForFood : MonoBehaviour
{
	public Text text;

	private float timeLeft = 300.0f;
	public Text timerText;
	
	// Use this for initialization
	void Start ()
	{
		text.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		//timer go
		timeLeft -= Time.deltaTime;
		timerText.text = "Time Left:" + Mathf.Round(timeLeft);
		if (timeLeft < 0)
		{
			timerText.text = "Game over";
		}
		
		//raycast for food
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.transform.gameObject.tag == "Death") //if you eat a nut, yiou die
				{
					text.enabled = true;
					text.text = "you killed me thanks";
					Destroy(hit.transform.gameObject);
				}
				
				if (hit.transform.gameObject.tag == "Safe") //if you eat not a nut, you win
                {
                   text.enabled = true;
                   text.text = "you win i guess?";
                   Destroy(hit.transform.gameObject);
                 }	
			}
		}
	}
}
