using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class rayCastForFood : MonoBehaviour
{
	public Text text;

	private float timeLeft = 40.0f;
	public Text timerText;
	public Text scoreText;
	private int score;
	private int nuts;
	
	// Use this for initialization
	void Start ()
	{
		text.enabled = false;

		score = 0;
		nuts = 0;
	}
	
	// Update is called once per frame
	void Update () {
		//timer go
		timeLeft -= Time.deltaTime;
		timerText.text = "Time Left:" + Mathf.Round(timeLeft);
		
		//game over if you haven't eaten anything good
		if ((timeLeft < 0) & (nuts > 0))
		{
			SceneManager.LoadScene("GameOver");
		}
		
		//game end if you have eaten some good boys
		if ((timeLeft < 0) && (nuts < 1) && (score > 0))
		{
			SceneManager.LoadScene("GameEnd");
		}
		
		//raycast for food
		if (Input.GetMouseButtonDown(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.transform.gameObject.tag == "Death") //decrease time left after eating a nut
				{
					timeLeft = timeLeft - 20.0f;
					text.enabled = true;
					nuts++;
					text.text = "Uh oh! Looks like that had some nuts in it.";
					Destroy(hit.transform.gameObject);
				}
				
				if (hit.transform.gameObject.tag == "Safe") //if you eat not a nut, you increase score
				{
					timeLeft = timeLeft + 10.0f;
	                score++;
                    Destroy(hit.transform.gameObject);
                 }	
				
				if (hit.transform.gameObject.tag == "Dont") //why would you eat an inedible object
				{
					text.enabled = true;
					text.text = "A forbidden snack...";
					score++;
					timeLeft = timeLeft + 10.0f;
					Destroy(hit.transform.gameObject);
				}	
			}
		}
		
		scoreText.text = "Snacks Eaten: " + score;
	}
}
