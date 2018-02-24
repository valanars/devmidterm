using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
		{
			SceneManager.LoadScene("GameScene");
		}

		if (Input.GetKeyDown(KeyCode.Backspace))
		{
			SceneManager.LoadScene("Menu");
		}
	}
}