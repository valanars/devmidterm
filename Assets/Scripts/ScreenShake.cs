using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScreenShake : MonoBehaviour {

	float shakeTimer = 0;

	float thisMagnitude = 0.6f;

	private Vector3 originPos;
	
	// Use this for initialization
	void Start ()
	{
		originPos = transform.localPosition;
	}
	
	public void Shake()
	{
		StartCoroutine("Screenshaker");
	}

	IEnumerator Screenshaker()
	{
		float shakeTime = 0.15f;
		
		//shake camera
		while (shakeTime > 0.0f)
		{
			Camera.main.transform.position = originPos + (Vector3)Random.insideUnitCircle * thisMagnitude;
			shakeTime -= Time.deltaTime;
			yield return 0;
		}
		
		//return cam to normal pos
		Camera.main.transform.position = originPos;
	}
}
