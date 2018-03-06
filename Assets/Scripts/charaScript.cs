using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class charaScript : MonoBehaviour
{
	private float timeLeft = 100.0f;
	public Text timerText;
	public Text scoreText;
	private int score;
	private int nuts;

	private bool zoom;

	public Image peanutInfo;
	public Image milkInfo;
	public Image bbInfo;
	public Image reesesInfo;
	public Image cheerInfo;
	public Image grassInfo;
	public Image fishInfo;
	public Image teethInfo;
	public Image meatInfo;

	private RaycastHit hit;

	// Use this for initialization
	void Start()
	{
		//set all the images to false
		peanutInfo.enabled = false;
		milkInfo.enabled = false;
		bbInfo.enabled = false;
		reesesInfo.enabled = false;
		cheerInfo.enabled = false;
		grassInfo.enabled = false;
		fishInfo.enabled = false;
		teethInfo.enabled = false;
		meatInfo.enabled = false;

		score = 0;
		nuts = 0;

		zoom = false;
	}

	// Update is called once per frame
	void Update()
	{
		//timer go
		timeLeft -= Time.deltaTime;
		timerText.text = "Time Left:" + Mathf.Round(timeLeft);
		scoreText.text = "Score:" + score;

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
			if (Physics.Raycast(ray, out hit))
			{
				zoom = true;
			}
		}

	//get food info
		if (zoom)
		{
			Image info = peanutInfo; //just set it to w/e bc it wont let me do shit otherwise lol
			GameObject food = hit.transform.gameObject;
			float timeChange = 0;
			int nutChange = 0;
			int scoreChange = 0;
			
			if (food.tag == "Peanut") //PEANUT
			{
				info = peanutInfo;
				timeChange = -20f;
				nutChange = 1;
			} else if (food.tag == "Milk") //MILK
			{
				info = milkInfo;
				timeChange = -20f;
				nutChange = 1;
			} else if (food.tag == "BreadBad") //NAUGHTY LOAF
			{
				info = bbInfo;
				timeChange = -20f;
				nutChange = 1;
			} else if (food.tag == "Reeses") //REESES
			{
				info = reesesInfo;
				timeChange = -20f;
				nutChange = 1;
			} else if (food.tag == "Cheerios") //CHEERIOS
			{
				info = cheerInfo;
				timeChange = -20f;
				nutChange = 1;
			} else if (food.tag == "Grass") //GRASS
			{
				info = grassInfo;
				timeChange = -20f;
				nutChange = 1;
			} else if (food.tag == "Fish") //FISH
			{
				info = fishInfo;
				timeChange = 0;
				nutChange = 0;
				scoreChange = 1;
			} else if (food.tag == "Teeth") //TEETH
			{
				info = teethInfo;
				timeChange = 0;
				nutChange = 0;
				scoreChange = 1;
			} else if (food.tag == "Meat") //MEAT
			{
				info = meatInfo;
				timeChange = 0;
				nutChange = 0;
				scoreChange = 1;
			}

			info.enabled = true;
			
			if (Input.GetKeyDown(KeyCode.Backspace)) //escape view
			{
				info.enabled = false;
				zoom = false;
			}
				
			if (Input.GetKeyDown(KeyCode.E)) //eat obj
			{
				timeLeft = timeLeft + timeChange;
				nuts = nuts + nutChange;
				score = score + scoreChange;
				Destroy(info);
				Destroy(food);
				zoom = false;
			}
		}
	}
}
